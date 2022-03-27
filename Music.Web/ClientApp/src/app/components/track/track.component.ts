import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Artist, Disc, Genre, Track } from '../../models';
import { TrackService, GenreService, DiscService, ArtistService } from '../../services';
import { Location } from '@angular/common';
import { FormControl } from '@angular/forms';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material/chips';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';

@Component({
  selector: 'app-track',
  templateUrl: './track.component.html',
  styleUrls: ['./track.component.css']
})
export class TrackComponent implements OnInit {
  public track: Track = <Track>{};
  public selectedArtists: Artist[] = [];

  // select fields
  public genres: Genre[] = [];
  public discs: Disc[] = [];

  // artists
  separatorKeysCodes: number[] = [ENTER, COMMA];
  public allArtists: Artist[] = [];
  filteredArtists: Observable<Artist[]>;
  artistCtrl = new FormControl();

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
      this.allArtists = artists
      this.filteredArtists = this.artistCtrl.valueChanges.pipe(
        startWith(null),
        map((artist: string | null) => (artist ? this._filter(artist) : this.allArtists.slice())),
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
      });
    });
  }

  saveTrack(): void {
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

  add(artist: Artist): void {
    if (artist) {
      this.selectedArtists.push(artist);
    }

    // // Clear the input value
    // event.chipInput!.clear();

    // this.fruitCtrl.setValue(null);
  }

  remove(artist: Artist): void {
    const index = this.selectedArtists.indexOf(artist);
    if (index >= 0) {
      this.selectedArtists.splice(index, 1);
    }
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    console.log(event);
    // this.selectedArtists.push(event.option.viewValue);
    // this.fruitInput.nativeElement.value = '';
    // this.fruitCtrl.setValue(null);
  }

  private _filter(value: string): Artist[] {
    const filterValue = value.toLowerCase();

    return this.allArtists.filter(artist => artist.name.toLowerCase().includes(filterValue));
  }

}
