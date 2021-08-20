import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ArtistService {

  constructor(
    private http: HttpClient,
    @Inject('API_URL') private baseUrl: string
  ) {
  }

  public getArtists(): Observable<Artist[]> {
    console.log(this.baseUrl);
    return this.http.get<Artist[]>(this.baseUrl + 'artists')
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
