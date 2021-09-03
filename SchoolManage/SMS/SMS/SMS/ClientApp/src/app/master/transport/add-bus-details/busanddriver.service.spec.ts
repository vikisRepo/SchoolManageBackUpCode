import { TestBed } from '@angular/core/testing';

import { BusanddriverService } from './busanddriver.service';

describe('BusanddriverService', () => {
  let service: BusanddriverService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BusanddriverService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
