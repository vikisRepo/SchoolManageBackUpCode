import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParentsGuardianDetailsComponent } from './parents-guardian-details.component';

describe('ParentsGuardianDetailsComponent', () => {
  let component: ParentsGuardianDetailsComponent;
  let fixture: ComponentFixture<ParentsGuardianDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ParentsGuardianDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ParentsGuardianDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
