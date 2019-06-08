import { TestBed } from '@angular/core/testing';

import { UniversidadService } from './universidad.service';

describe('UniversidadService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UniversidadService = TestBed.get(UniversidadService);
    expect(service).toBeTruthy();
  });
});
