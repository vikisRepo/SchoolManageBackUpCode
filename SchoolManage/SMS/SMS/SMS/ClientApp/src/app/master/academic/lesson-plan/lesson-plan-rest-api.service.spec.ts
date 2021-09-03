import { TestBed } from '@angular/core/testing';

import { LessonPlanRestApiService } from './lesson-plan-rest-api.service';

describe('LessonPlanRestApiService', () => {
  let service: LessonPlanRestApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LessonPlanRestApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
