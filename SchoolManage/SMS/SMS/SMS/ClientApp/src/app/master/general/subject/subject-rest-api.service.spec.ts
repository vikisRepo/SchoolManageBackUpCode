import { TestBed } from '@angular/core/testing';

import { SubjectRestApiService } from './subject-rest-api.service';

describe('SubjectRestApiService', () => {
  let service: SubjectRestApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SubjectRestApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
