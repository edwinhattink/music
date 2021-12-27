import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Album } from '../models/album';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class AlbumService extends BaseService<Album> {

  constructor(
    http: HttpClient,
    @Inject('API_URL') baseUrl: string
  ) {
    super(http,  `${baseUrl}/albums`);
  }

  protected mapToSend(model: Album): object {
    return {
      id: model.id,
      name: model.name,
      releaseYear: model.releaseYear,
    };
  }

}
