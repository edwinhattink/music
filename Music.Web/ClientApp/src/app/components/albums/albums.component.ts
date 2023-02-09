import { Component, OnInit } from '@angular/core';
import { AlbumService } from '../../services';
import { Album } from '../../models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-albums',
  templateUrl: './albums.component.html',
  styleUrls: ['./albums.component.css']
})
export class AlbumsComponent implements OnInit {
  public displayedColumns: string[] = ['id', 'name', 'year'];
  public albums: Album[] = [];

  constructor(
    private albumService: AlbumService,
    private router: Router
    ) {
    albumService.getList().subscribe(albums => this.albums = albums);
  }

  ngOnInit(): void {
  }

  goToAlbum(album: Album): void {
    this.router.navigate(['albums', album.id]);
  }
}
