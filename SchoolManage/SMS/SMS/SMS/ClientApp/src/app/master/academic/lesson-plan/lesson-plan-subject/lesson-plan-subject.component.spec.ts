import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LessonPlanSubjectComponent } from './lesson-plan-subject.component';

describe('LessonPlanSubjectComponent', () => {
  let component: LessonPlanSubjectComponent;
  let fixture: ComponentFixture<LessonPlanSubjectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LessonPlanSubjectComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LessonPlanSubjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
