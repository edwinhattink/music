import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Disc } from '../models/disc';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class DiscService extends BaseService<Disc> {

  constructor(
    http: HttpClient,
    @Inject('API_URL') baseUrl: string
  ) {
    super(http,  `${baseUrl}/discs`);
  }

  protected mapToSend(model: Disc): object {
    return {
      id: model.id,
      albumId: model.album?.id,
      number: model.number,
    };
  }
}
