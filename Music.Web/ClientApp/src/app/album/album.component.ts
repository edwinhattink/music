import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Album } from '../models/album';
import { AlbumService } from '../services/album.service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-album',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.css']
})
export class AlbumComponent implements OnInit {

  album: Album;

  constructor(
    private albumService: AlbumService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (isNaN(params.id) === true) {
        this.album = {
          name: null,
          releaseYear: null,
        };
        return;
      }
      this.albumService.getAlbum(params.id).subscribe(album => {
        this.album = album;
      });
    });
  }

  saveAlbum(): void {
    if (this.album.id) {
      this.albumService.updateAlbum(this.album).subscribe();
    } else {
      this.albumService.createAlbum(this.album)
        .subscribe(album => {
          this.album = album;
        });
    }
  }

  deleteAlbum(): void {
    if (this.album.id) {
      this.albumService.deleteAlbum(this.album).subscribe(() => {
        this.location.back();
      });
    }
  }

}
