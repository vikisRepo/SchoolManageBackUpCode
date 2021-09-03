import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLesonPlanSubjectwiseComponent } from './add-leson-plan-subjectwise.component';

describe('AddLesonPlanSubjectwiseComponent', () => {
  let component: AddLesonPlanSubjectwiseComponent;
  let fixture: ComponentFixture<AddLesonPlanSubjectwiseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddLesonPlanSubjectwiseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddLesonPlanSubjectwiseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
