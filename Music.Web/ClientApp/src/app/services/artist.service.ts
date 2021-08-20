import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Artist } from '../models/artist';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class ArtistService {

  private baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('API_URL') baseUrl: string
  ) {
    this.baseUrl = `${baseUrl}/artists`;
  }

  public getArtists(): Observable<Artist[]> {
    return this.http.get<Artist[]>(this.baseUrl)
      .pipe(
        catchError(this.handleError)
      );
  }

  public createArtist(artist: Artist): Observable<Artist> {
    return this.http.post<Artist>(this.baseUrl, artist, httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  handleError(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // client-side error
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // server-side error
      errorMessage = `Error Code: ${error.status} \nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);

  }
}
