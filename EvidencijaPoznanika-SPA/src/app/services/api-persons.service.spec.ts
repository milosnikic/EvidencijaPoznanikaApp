import { TestBed } from '@angular/core/testing';

import { ApiPersonsService } from './api-persons.service';

describe('ApiPersonsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ApiPersonsService = TestBed.get(ApiPersonsService);
    expect(service).toBeTruthy();
  });
});
