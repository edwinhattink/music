import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-artists',
  templateUrl: './artists.component.html',
  styleUrls: ['./artists.component.css']
})
export class ArtistsComponent implements OnInit {
  public artists: Artist[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Artist[]>(baseUrl + 'api/artists').subscribe(result => {
      this.artists = result;
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }
}

interface Artist {
  id: number;
  name: string;
}
