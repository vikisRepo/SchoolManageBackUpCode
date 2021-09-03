import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TargetStudentComponent } from './target-student.component';

describe('TargetStudentComponent', () => {
  let component: TargetStudentComponent;
  let fixture: ComponentFixture<TargetStudentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TargetStudentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TargetStudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
