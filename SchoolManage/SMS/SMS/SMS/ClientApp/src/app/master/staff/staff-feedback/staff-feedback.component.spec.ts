import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StaffFeedbackComponent } from './staff-feedback.component';

describe('StaffFeedbackComponent', () => {
  let component: StaffFeedbackComponent;
  let fixture: ComponentFixture<StaffFeedbackComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StaffFeedbackComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StaffFeedbackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
