import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Track } from '../models/track';
import { TrackService } from '../services/track.service';
import { Location } from '@angular/common';
import { GenreService } from '../services/genre.service';
import { Genre } from '../models/genre';
import { Disc } from '../models/disc';
import { DiscService } from '../services/disc.service';

@Component({
  selector: 'app-track',
  templateUrl: './track.component.html',
  styleUrls: ['./track.component.css']
})
export class TrackComponent implements OnInit {
  public track: Track = <Track>{};
  public genres: Genre[] = [];
  public discs: Disc[] = [];

  constructor(
    private trackService: TrackService,
    private route: ActivatedRoute,
    private location: Location,
    private genreService: GenreService,
    private discService: DiscService,
  ) { 
    genreService.getList().subscribe(genres => this.genres = genres);
    discService.getList().subscribe(discs => this.discs = discs);
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

}
