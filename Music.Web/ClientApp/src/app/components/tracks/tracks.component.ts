import { Component, OnInit } from '@angular/core';
import { TrackService } from '../../services';
import { ContributionType, Track } from '../../models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tracks',
  templateUrl: './tracks.component.html',
  styleUrls: ['./tracks.component.css']
})
export class TracksComponent implements OnInit {
  public displayedColumns: string[] = ['id', 'number', 'artist', 'album', 'name'];
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

  trackNameDisplay(track: Track): string {
    const remixArtists: string[] = [];
    track.contributions.forEach(c => {
      if (c.contributionType == ContributionType.REMIX) {
        remixArtists.push(c.artist.name);
      }
    })

    if (remixArtists.length < 1) {
      return track.name;
    }

    return `${track.name} (${remixArtists.join(" & ")} Remix)`;
  }

  artistDisplay(track: Track): string {
    const artists: string[] = [];
    track.contributions.forEach(c => {
      if (c.contributionType != ContributionType.REMIX) {
        artists.push(c.artist.name);
      }
    });
    return artists.join(" & ");
  }
}
