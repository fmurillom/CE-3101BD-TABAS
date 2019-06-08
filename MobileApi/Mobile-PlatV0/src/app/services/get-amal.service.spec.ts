import { TestBed } from '@angular/core/testing';

import { GetAMalService } from './get-amal.service';

describe('GetAMalService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: GetAMalService = TestBed.get(GetAMalService);
    expect(service).toBeTruthy();
  });
});
