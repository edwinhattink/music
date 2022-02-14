import { Component, OnInit } from '@angular/core';
import { ArtistService } from '../services/artist.service';
import { Artist } from '../models/artist';
import { Router } from '@angular/router';

@Component({
  selector: 'app-artists',
  templateUrl: './artists.component.html',
  styleUrls: ['./artists.component.css']
})
export class ArtistsComponent implements OnInit {
  public displayedColumns: string[] = ['id', 'name'];
  public artists: Artist[] = [];

  constructor(
    private artistService: ArtistService,
    private router: Router
  ) {
    artistService.getList().subscribe(artists => this.artists = artists);
  }

  ngOnInit(): void {
  }

  goToArtist(artist: Artist): void {
    this.router.navigate(['artists', artist.id]);
  }
}
