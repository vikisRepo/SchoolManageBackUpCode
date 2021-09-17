import { TestBed } from '@angular/core/testing';

import { FactorydataService } from './factorydata.service';

describe('FactorydataService', () => {
  let service: FactorydataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FactorydataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
