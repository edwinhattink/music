import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Track } from '../models/track';
import { TrackService } from '../services/track.service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-track',
  templateUrl: './track.component.html',
  styleUrls: ['./track.component.css']
})
export class TrackComponent implements OnInit {
  public track: Track = <Track>{};

  constructor(
    private trackService: TrackService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (isNaN(params.id) === true) {
        this.track = <Track>{};
        return;
      }
      this.trackService.getId(params.id).subscribe(track => {
        this.track = track;
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
