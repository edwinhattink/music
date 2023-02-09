import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Genre } from '../../models';
import { GenreService } from '../../services';
import {Location} from '@angular/common';

@Component({
  selector: 'app-genre',
  templateUrl: './genre.component.html',
  styleUrls: ['./genre.component.css']
})
export class GenreComponent implements OnInit {
  public genre: Genre = <Genre>{};
  public selectableGenres: Genre[] = [];

  constructor(
    private genreService: GenreService,
    private route: ActivatedRoute,
    private location: Location,
    private router: Router
  ) {
    genreService.getList().subscribe(genres => this.selectableGenres = genres);
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (isNaN(params.id) === true) {
        this.genre = <Genre>{};
        return;
      }
      this.genreService.getId(params.id).subscribe(genre => {
        this.genre = genre;
        if (genre.parentGenre) {
          this.genre.parentGenre = this.selectableGenres.find(g => g.id === genre.parentGenre?.id);
        }
      });
    });
  }

  saveGenre(): void {
    if (this.genre.id) {
      this.genreService.update(this.genre).subscribe();
    } else {
      this.genreService.create(this.genre)
        .subscribe(genre => {
          this.router.navigate(['/genres', genre.id]);
        });
    }
  }

  deleteGenre(): void {
    if (this.genre.id) {
      this.genreService.delete(this.genre).subscribe(() => {
        this.location.back();
      });
    }
  }

}
