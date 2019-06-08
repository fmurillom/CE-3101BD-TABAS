import { TestBed } from '@angular/core/testing';

import { GetBCService } from './get-bc.service';

describe('GetBCService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: GetBCService = TestBed.get(GetBCService);
    expect(service).toBeTruthy();
  });
});
