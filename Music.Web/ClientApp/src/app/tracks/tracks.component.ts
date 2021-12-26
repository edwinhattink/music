import { Component, OnInit } from '@angular/core';
import { TrackService } from '../services/track.service';
import { Track } from '../models/track';

@Component({
  selector: 'app-tracks',
  templateUrl: './tracks.component.html',
  styleUrls: ['./tracks.component.css']
})
export class TracksComponent implements OnInit {
  public tracks: Track[] = [];

  constructor(private trackService: TrackService) {
    trackService.getList().subscribe(tracks => this.tracks = tracks);
  }

  ngOnInit(): void {
  }

}
