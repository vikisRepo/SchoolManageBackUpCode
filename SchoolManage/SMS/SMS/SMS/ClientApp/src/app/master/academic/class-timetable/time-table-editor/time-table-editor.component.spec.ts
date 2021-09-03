import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimeTableEditorComponent } from './time-table-editor.component';

describe('TimeTableEditorComponent', () => {
  let component: TimeTableEditorComponent;
  let fixture: ComponentFixture<TimeTableEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TimeTableEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TimeTableEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
