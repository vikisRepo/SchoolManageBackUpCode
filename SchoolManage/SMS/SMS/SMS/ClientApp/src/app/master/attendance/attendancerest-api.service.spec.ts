import { TestBed } from '@angular/core/testing';

import { AttendancerestApiService } from './attendancerest-api.service';

describe('AttendancerestApiService', () => {
  let service: AttendancerestApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AttendancerestApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
