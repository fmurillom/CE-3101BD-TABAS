import { TestBed } from '@angular/core/testing';

import { BagCartService } from './bag-cart.service';

describe('BagCartService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BagCartService = TestBed.get(BagCartService);
    expect(service).toBeTruthy();
  });
});
