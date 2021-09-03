import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseSubjectwiseComponent } from './course-subjectwise.component';

describe('CourseSubjectwiseComponent', () => {
  let component: CourseSubjectwiseComponent;
  let fixture: ComponentFixture<CourseSubjectwiseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CourseSubjectwiseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CourseSubjectwiseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
