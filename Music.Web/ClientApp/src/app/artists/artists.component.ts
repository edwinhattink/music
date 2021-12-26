import { Component, OnInit } from '@angular/core';
import { ArtistService } from '../services/artist.service';
import { Artist } from '../models/artist';

@Component({
  selector: 'app-artists',
  templateUrl: './artists.component.html',
  styleUrls: ['./artists.component.css']
})
export class ArtistsComponent implements OnInit {
  public artists: Artist[] = [];

  constructor(private artistService: ArtistService) {
    artistService.getList().subscribe(artists => this.artists = artists);
  }

  ngOnInit(): void {
  }

}
