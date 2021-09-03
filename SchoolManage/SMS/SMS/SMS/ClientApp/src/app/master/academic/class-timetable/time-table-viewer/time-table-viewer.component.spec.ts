import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimeTableViewerComponent } from './time-table-viewer.component';

describe('TimeTableViewerComponent', () => {
  let component: TimeTableViewerComponent;
  let fixture: ComponentFixture<TimeTableViewerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TimeTableViewerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TimeTableViewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
