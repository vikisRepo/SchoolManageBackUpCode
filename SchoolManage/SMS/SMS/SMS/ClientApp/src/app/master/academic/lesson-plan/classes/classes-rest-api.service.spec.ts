import { TestBed } from '@angular/core/testing';

import { ClassesRestApiService } from './classes-rest-api.service';

describe('ClassesRestApiService', () => {
  let service: ClassesRestApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClassesRestApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
