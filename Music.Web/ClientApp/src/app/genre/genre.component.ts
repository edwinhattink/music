import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Genre } from '../models/genre';
import { GenreService } from '../services/genre.service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-genre',
  templateUrl: './genre.component.html',
  styleUrls: ['./genre.component.css']
})
export class GenreComponent implements OnInit {
  public genre: Genre = <Genre>{};

  constructor(
    private genreService: GenreService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (isNaN(params.id) === true) {
        this.genre = <Genre>{};
        return;
      }
      this.genreService.getId(params.id).subscribe(genre => {
        this.genre = genre;
      });
    });
  }

  saveGenre(): void {
    if (this.genre.id) {
      this.genreService.update(this.genre).subscribe();
    } else {
      this.genreService.create(this.genre)
        .subscribe(genre => {
          this.genre = genre;
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
