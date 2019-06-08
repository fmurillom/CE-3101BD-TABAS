import { TestBed } from '@angular/core/testing';

import { MaxmarcasService } from './maxmarcas.service';

describe('MaxmarcasService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MaxmarcasService = TestBed.get(MaxmarcasService);
    expect(service).toBeTruthy();
  });
});
