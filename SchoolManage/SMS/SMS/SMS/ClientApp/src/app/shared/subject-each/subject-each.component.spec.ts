import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubjectEachComponent } from './subject-each.component';

describe('SubjectEachComponent', () => {
  let component: SubjectEachComponent;
  let fixture: ComponentFixture<SubjectEachComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubjectEachComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubjectEachComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
