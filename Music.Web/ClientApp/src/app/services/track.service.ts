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
    super(http, `${baseUrl}/tracks`);
  }

  protected mapToSend(model: Track): object {
    return {
      id: model.id,
      name: model.name,
      number: model.number,
      parentGenreId: model.genre?.id,
    };
  }
}
