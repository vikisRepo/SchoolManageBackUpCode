import { TestBed } from '@angular/core/testing';

import { StudentrestApiService } from './studentrest-api.service';

describe('StudentrestApiService', () => {
  let service: StudentrestApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StudentrestApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
