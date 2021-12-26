import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Genre } from '../models/genre';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class GenreService extends BaseService<Genre> {
  constructor(
    http: HttpClient,
    @Inject('API_URL') baseUrl: string
  ) {
    super(http,  `${baseUrl}/genres`);
  }
}
