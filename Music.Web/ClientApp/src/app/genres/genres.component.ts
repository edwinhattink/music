import { Component, OnInit } from '@angular/core';
import { GenreService } from '../services/genre.service';
import { Genre } from '../models/genre';

@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})
export class GenresComponent implements OnInit {
  public genres: Genre[] = [];

  constructor(private genreService: GenreService) {
    genreService.getList().subscribe(genres => this.genres = genres);
  }

  ngOnInit(): void {
  }

}
