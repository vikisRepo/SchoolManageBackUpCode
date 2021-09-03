import { TestBed } from '@angular/core/testing';

import { ClassGradeRestApiService } from './class-grade-rest-api.service';

describe('ClassGradeRestApiService', () => {
  let service: ClassGradeRestApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClassGradeRestApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
