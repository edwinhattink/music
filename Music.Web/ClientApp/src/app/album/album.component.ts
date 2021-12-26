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

  public album: Album = <Album>{};

  constructor(
    private albumService: AlbumService,
    private route: ActivatedRoute,
    private location: Location
  ) {
   }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (isNaN(params.id) === true) {
        this.album = <Album>{};
        return;
      }
      this.albumService.getId(params.id).subscribe(album => {
        this.album = album;
      });
    });
  }

  saveAlbum(): void {
    if (this.album.id) {
      this.albumService.update(this.album).subscribe();
    } else {
      this.albumService.create(this.album)
        .subscribe(album => {
          this.album = album;
        });
    }
  }

  deleteAlbum(): void {
    if (this.album.id) {
      this.albumService.delete(this.album).subscribe(() => {
        this.location.back();
      });
    }
  }

}
