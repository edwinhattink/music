import { TestBed } from '@angular/core/testing';

import { ContributionTypeService } from './contribution-type.service';

describe('ContributionTypeService', () => {
  let service: ContributionTypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ContributionTypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
