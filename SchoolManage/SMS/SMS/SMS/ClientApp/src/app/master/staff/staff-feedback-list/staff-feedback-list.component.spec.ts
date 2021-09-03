import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StaffFeedbackListComponent } from './staff-feedback-list.component';

describe('StaffFeedbackListComponent', () => {
  let component: StaffFeedbackListComponent;
  let fixture: ComponentFixture<StaffFeedbackListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StaffFeedbackListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StaffFeedbackListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
