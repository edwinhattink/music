import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Album } from '../models/album';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class AlbumService {

  private baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('API_URL') baseUrl: string
  ) {
    this.baseUrl = `${baseUrl}/albums`;
  }

  public getAlbums(): Observable<Album[]> {
    return this.http.get<Album[]>(this.baseUrl)
      .pipe(
        catchError(this.handleError)
      );
  }

  public getAlbum(albumId: number): Observable<Album> {
    return this.http.get<Album>(`${this.baseUrl}/${albumId}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  public createAlbum(album: Album): Observable<Album> {
    return this.http.post<Album>(this.baseUrl, album, httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  public updateAlbum(album: Album): Observable<object> {
    return this.http.put(`${this.baseUrl}/${album.id}`, album, httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  public deleteAlbum(album: Album): Observable<object> {
    return this.http.delete(`${this.baseUrl}/${album.id}`, httpOptions)
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
    console.error(errorMessage);
    return throwError(errorMessage);

  }
}
