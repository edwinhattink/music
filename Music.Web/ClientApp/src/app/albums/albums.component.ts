import { Component, OnInit } from '@angular/core';
import { AlbumService } from '../services/album.service';
import { Album } from '../models/album';

@Component({
  selector: 'app-albums',
  templateUrl: './albums.component.html',
  styleUrls: ['./albums.component.css']
})
export class AlbumsComponent implements OnInit {
  public displayedColumns: string[] = ['id', 'name', 'year'];
  public albums: Album[] = [];

  constructor(private albumService: AlbumService) {
    albumService.getList().subscribe(albums => this.albums = albums);
  }

  ngOnInit(): void {
  }

}
