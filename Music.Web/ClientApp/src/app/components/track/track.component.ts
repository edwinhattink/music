import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Artist, Contribution, ContributionType, Disc, Genre, Track } from '../../models';
import { TrackService, GenreService, DiscService, ArtistService } from '../../services';
import { Location } from '@angular/common';
import { FormControl } from '@angular/forms';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material/chips';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { findById } from 'src/app/functions/model-functions';

@Component({
  selector: 'app-track',
  templateUrl: './track.component.html',
  styleUrls: ['./track.component.css']
})
export class TrackComponent implements OnInit {
  public track: Track = <Track>{};
  public contributions: Contribution[] = [];

  // select fields
  public genres: Genre[] = [];
  public discs: Disc[] = [];

  // artists
  separatorKeysCodes: number[] = [ENTER, COMMA];
  public allArtists: Artist[] = [];
  filteredArtists: Observable<Artist[]>;
  artistCtrl = new FormControl();
  contributionType = ContributionType;
  contributionTypes: ContributionType[] = [ContributionType.MAIN, ContributionType.FEATURING, ContributionType.REMIX];

  @ViewChild('artistInput') artistInput: ElementRef<HTMLInputElement>;

  constructor(
    private trackService: TrackService,
    private route: ActivatedRoute,
    private location: Location,
    private genreService: GenreService,
    private discService: DiscService,
    private artistService: ArtistService,
  ) {
    genreService.getList().subscribe(genres => this.genres = genres);
    discService.getList().subscribe(discs => this.discs = discs);
    this.filteredArtists = new Observable();
    artistService.getList().subscribe(artists => {
      this.allArtists = artists;

      this.filteredArtists = this.artistCtrl.valueChanges.pipe(
        startWith(null),
        map((artist: string | Artist | null) => {
          if (artist instanceof Object) {
            return this.allArtists;
          }
          return this._filterArtists(artist);
        }),
      );
    });
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (isNaN(params.id) === true) {
        this.track = <Track>{};
        return;
      }
      this.trackService.getId(params.id).subscribe(track => {
        this.track = track;
        if (track.genreId) {
          this.track.genre = this.genres.find(g => g.id === track.genreId);
        }
        if (track.discId) {
          this.track.disc = this.discs.find(d => d.id === track.discId);
        }
        for (const contribution of track.contributions) {
          this.contributions.push(<Contribution>{
            artist: findById(this.allArtists, contribution.artistId),
            contributionType: contribution.contributionType
          });
        }
      });
    });
  }

  saveTrack(): void {
    this.track.contributions = this.contributions;
    if (this.track.id) {
      this.trackService.update(this.track).subscribe();
    } else {
      this.trackService.create(this.track)
        .subscribe(track => {
          this.track = track;
        });
    }
  }

  deleteTrack(): void {
    if (this.track.id) {
      this.trackService.delete(this.track).subscribe(() => {
        this.location.back();
      });
    }
  }

  addArtistByName(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    if (value) {
      this.contributions.push(<Contribution>{
        artist: this._findArtistByName(value),
        contributionType: ContributionType.MAIN
      });
    }

    // Clear the input value
    if (event.chipInput !== undefined) {
      event.chipInput.clear();
    }
    this.artistCtrl.setValue(null);
  }

  remove(artist: Artist): void {
    const index = this.contributions.map(c => c.artist.id).indexOf(artist.id);
    if (index >= 0) {
      this.contributions.splice(index, 1);
    }
  }

  selectedArtist(event: MatAutocompleteSelectedEvent): void {
    this.contributions.push(<Contribution>{
      artist: this._findArtistByIdInArray(event.option.value.id, this.allArtists),
      contributionType: ContributionType.MAIN
    });
    this.artistInput.nativeElement.value = '';
    this.artistCtrl.setValue(null);
  }

  private _filterArtists(value: string | null): Artist[] {
    if (value) {
      return this._filterArtistInArray(value, this.allArtists).filter(artist => !this.contributions.find(a => a.id === artist.id));
    }
    return this.allArtists.filter(artist => !this.contributions.find(a => a.id === artist.id));
  }

  private _findArtistByIdInArray(id: number, artists: Artist[]) {
    return artists.find(a => a.id == id);
  }

  private _filterArtistInArray(name: string, artists: Artist[]) {
    const filterValue = name.toLowerCase();
    return artists.filter(a => a.name.toLowerCase().includes(filterValue));
  }

  private _findArtistByName(value: string): Artist {
    const foundArtists = this._filterArtistInArray(value, this.allArtists);
    if (foundArtists.length > 1) {
      throw new Error('Meerdere artiesten gevonden');
    }
    if (foundArtists.length === 1) {
      return foundArtists[0];
    }
    throw new Error('Geen artist gevonden');
  }

}
