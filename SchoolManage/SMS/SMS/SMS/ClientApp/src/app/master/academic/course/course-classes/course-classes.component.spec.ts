import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseClassesComponent } from './course-classes.component';

describe('CourseClassesComponent', () => {
  let component: CourseClassesComponent;
  let fixture: ComponentFixture<CourseClassesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CourseClassesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CourseClassesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
