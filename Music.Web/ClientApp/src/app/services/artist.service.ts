import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Artist } from '../models/artist';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class ArtistService extends BaseService<Artist> {
  constructor(
    http: HttpClient,
    @Inject('API_URL') baseUrl: string
  ) {
    super(http,  `${baseUrl}/artists`);
  }
}
