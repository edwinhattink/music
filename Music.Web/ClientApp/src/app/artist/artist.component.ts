import { Component, OnInit } from '@angular/core';
import { Artist } from '../models/artist';
import { ArtistService } from '../services/artist.service';

@Component({
  selector: 'app-artist',
  templateUrl: './artist.component.html',
  styleUrls: ['./artist.component.css']
})
export class ArtistComponent implements OnInit {

  artist: Artist;

  constructor(private artistService: ArtistService) { }

  ngOnInit() {
    this.artist = {
      name: null,
    };
  }

  saveArtist(): void {
    this.artistService.createArtist(this.artist)
      .subscribe(artist => {
        this.artist = artist;
      });
  }

}
