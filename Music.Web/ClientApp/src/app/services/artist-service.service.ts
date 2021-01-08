import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Artist } from '../resources';

@Injectable({
  providedIn: 'root'
})
export class ArtistServiceService {

  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public getArtists(): Observable<Artist[]> {
    return this.http.get<Artist[]>(`${this.baseUrl}/api`);
  }
}
