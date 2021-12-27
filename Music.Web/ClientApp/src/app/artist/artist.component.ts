import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Artist } from '../models/artist';
import { ArtistService } from '../services/artist.service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-artist',
  templateUrl: './artist.component.html',
  styleUrls: ['./artist.component.css']
})
export class ArtistComponent implements OnInit {

  public artist: Artist = <Artist>{};

  constructor(
    private artistService: ArtistService,
    private route: ActivatedRoute,
    private location: Location
  ) {
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (isNaN(params.id) === true) {
        this.artist = <Artist>{};
        return;
      }
      this.artistService.getId(params.id).subscribe(artist => {
        this.artist = artist;
      });
    });
  }

  saveArtist(): void {
    if (this.artist.id) {
      this.artistService.update(this.artist).subscribe();
    } else {
      this.artistService.create(this.artist)
        .subscribe(artist => {
          this.artist = artist;
        });
    }
  }

  deleteArtist(): void {
    if (this.artist.id) {
      this.artistService.delete(this.artist).subscribe(() => {
        this.location.back();
      });
    }
  }

}
