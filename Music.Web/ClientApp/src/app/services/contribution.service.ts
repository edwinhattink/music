import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Contribution } from '../models';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class ContributionService extends BaseService<Contribution> {
  constructor(
    http: HttpClient,
    @Inject('API_URL') baseUrl: string
  ) {
    super(http, `${baseUrl}/contributions`);
  }

  protected mapToSend(model: Contribution): object {
    return {
      id: model.id,
      trackId: model.track?.id,
      artistId: model.artist?.id,
      contributionType: model.contributionType
    };
  }
}
