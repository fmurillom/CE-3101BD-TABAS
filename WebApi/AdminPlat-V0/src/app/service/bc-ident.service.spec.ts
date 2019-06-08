import { TestBed } from '@angular/core/testing';

import { BcIdentService } from './bc-ident.service';

describe('BcIdentService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BcIdentService = TestBed.get(BcIdentService);
    expect(service).toBeTruthy();
  });
});
