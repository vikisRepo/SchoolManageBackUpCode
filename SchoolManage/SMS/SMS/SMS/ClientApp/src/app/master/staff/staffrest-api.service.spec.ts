import { TestBed } from '@angular/core/testing';

import { StaffrestApiService } from './staffrest-api.service';

describe('StaffrestApiService', () => {
  let service: StaffrestApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StaffrestApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
