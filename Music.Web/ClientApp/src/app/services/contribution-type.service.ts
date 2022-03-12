import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { ContributionType } from '../models';
import { BaseService } from './base.service';

// Deze extends is overkill, je kan alleen gebruik maken van GetList.
@Injectable({
  providedIn: 'root'
})
export class ContributionTypeService extends BaseService<ContributionType> {
  constructor(
    http: HttpClient,
    @Inject('API_URL') baseUrl: string
  ) {
    super(http,  `${baseUrl}/contributionTypes`);
  }

  protected mapToSend(model: ContributionType): object {
    return {
      id: model.id,
    };
  }
}
