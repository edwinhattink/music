import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Track } from '../models/track';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class TrackService extends BaseService<Track> {
  constructor(
    http: HttpClient,
    @Inject('API_URL') baseUrl: string
  ) {
    super(http,  `${baseUrl}/tracks`);
  }
}
