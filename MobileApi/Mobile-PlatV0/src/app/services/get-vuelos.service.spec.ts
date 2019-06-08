import { TestBed } from '@angular/core/testing';

import { GetVuelosService } from './get-vuelos.service';

describe('GetVuelosService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: GetVuelosService = TestBed.get(GetVuelosService);
    expect(service).toBeTruthy();
  });
});
