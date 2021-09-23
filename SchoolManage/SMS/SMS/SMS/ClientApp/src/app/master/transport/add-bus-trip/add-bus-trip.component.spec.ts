import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBusTripComponent } from './add-bus-trip.component';

describe('AddBusTripComponent', () => {
  let component: AddBusTripComponent;
  let fixture: ComponentFixture<AddBusTripComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddBusTripComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddBusTripComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
