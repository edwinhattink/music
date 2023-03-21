import { Component, OnInit } from '@angular/core';
import { TrackService } from '../../services';
import { Track } from '../../models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tracks',
  templateUrl: './tracks.component.html',
  styleUrls: ['./tracks.component.css']
})
export class TracksComponent implements OnInit {
  public displayedColumns: string[] = ['id', 'number', 'artist', 'name'];
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

  artistDisplay(track: Track): string {
    return track.contributions.map((contribution) => {
      return contribution.artist.name;
    }).join(" & ");
  }
}
