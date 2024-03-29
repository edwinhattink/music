import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Album, Disc } from '../../models';
import { AlbumService, DiscService } from '../../services';
import {Location} from '@angular/common';

@Component({
  selector: 'app-disc',
  templateUrl: './disc.component.html',
  styleUrls: ['./disc.component.css']
})
export class DiscComponent implements OnInit {
  public disc: Disc = <Disc>{};
  public albums: Album[] = [];

  constructor(
    private discService: DiscService,
    private route: ActivatedRoute,
    private location: Location,
    private albumService: AlbumService
  ) {
    albumService.getList().subscribe(albums => this.albums = albums);
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (isNaN(params.id) === true) {
        this.disc = <Disc>{};
        return;
      }
      this.discService.getId(params.id).subscribe(disc => {
        this.disc = disc;
        if (this.disc.albumId) {
          this.disc.album = this.albums.find(album => album.id === this.disc.id);
        }
      });
    });
  }

  saveDisc(): void {
    if (this.disc.id) {
      this.discService.update(this.disc).subscribe();
    } else {
      this.discService.create(this.disc)
        .subscribe(disc => {
          this.disc = disc;
        });
    }
  }

  deleteDisc(): void {
    if (this.disc.id) {
      this.discService.delete(this.disc).subscribe(() => {
        this.location.back();
      });
    }
  }

}
