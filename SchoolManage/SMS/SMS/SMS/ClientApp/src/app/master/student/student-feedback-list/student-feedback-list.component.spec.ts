import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentFeedbackListComponent } from './student-feedback-list.component';

describe('StudentFeedbackListComponent', () => {
  let component: StudentFeedbackListComponent;
  let fixture: ComponentFixture<StudentFeedbackListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentFeedbackListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentFeedbackListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
