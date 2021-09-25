import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListBusTripsComponent } from './list-bus-trips.component';

describe('ListBusTripsComponent', () => {
  let component: ListBusTripsComponent;
  let fixture: ComponentFixture<ListBusTripsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListBusTripsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListBusTripsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
