import { TestBed } from '@angular/core/testing';

import { GetIdMalService } from './get-id-mal.service';

describe('GetIdMalService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: GetIdMalService = TestBed.get(GetIdMalService);
    expect(service).toBeTruthy();
  });
});
