import { Component, OnInit } from '@angular/core';
import { TrackService } from '../services/track.service';
import { Track } from '../models/track';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tracks',
  templateUrl: './tracks.component.html',
  styleUrls: ['./tracks.component.css']
})
export class TracksComponent implements OnInit {
  public displayedColumns: string[] = ['id', 'number', 'name'];
  public tracks: Track[] = [];

  constructor(
    private trackService: TrackService,
    private router: Router
  ) {
    trackService.getList().subscribe(tracks => this.tracks = tracks);
  }

  ngOnInit(): void {
  }

  goToTrack(track: Track): void {
    this.router.navigate(['tracks', track.id]);
  }
}
