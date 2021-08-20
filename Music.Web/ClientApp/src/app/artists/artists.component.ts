import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ArtistService } from '../services/artist.service';

@Component({
  selector: 'app-artists',
  templateUrl: './artists.component.html',
  styleUrls: ['./artists.component.css']
})
export class ArtistsComponent implements OnInit {
  public artists: Artist[];

  constructor(private artistService: ArtistService) {
    artistService.getArtists().subscribe(artists => this.artists = artists);
  }

  ngOnInit(): void {
  }
}
