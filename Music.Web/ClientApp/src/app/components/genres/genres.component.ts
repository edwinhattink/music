import { Component, OnInit } from '@angular/core';
import { GenreService } from '../../services';
import { Genre } from '../../models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})
export class GenresComponent implements OnInit {
  public displayedColumns: string[] = ['id', 'name', 'parentGenre'];
  public genres: Genre[] = [];

  constructor(
    private genreService: GenreService,
    private router: Router
  ) {
    genreService.getList().subscribe(genres => this.genres = genres);
  }

  ngOnInit(): void {
  }

  goToGenre(genre: Genre): void {
    this.router.navigate(['genres', genre.id]);
  }

}
