import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLessonPlanListviewComponent } from './add-lesson-plan-listview.component';

describe('AddLessonPlanListviewComponent', () => {
  let component: AddLessonPlanListviewComponent;
  let fixture: ComponentFixture<AddLessonPlanListviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddLessonPlanListviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddLessonPlanListviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
