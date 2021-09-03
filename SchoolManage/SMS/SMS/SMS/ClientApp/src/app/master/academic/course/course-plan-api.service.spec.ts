import { TestBed } from '@angular/core/testing';

import { CoursePlanApiService } from './course-plan-api.service';

describe('CoursePlanApiService', () => {
  let service: CoursePlanApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CoursePlanApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
