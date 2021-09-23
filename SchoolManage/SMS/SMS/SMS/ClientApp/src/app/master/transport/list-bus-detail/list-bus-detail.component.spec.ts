import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListBusDetailComponent } from './list-bus-detail.component';

describe('ListBusDetailComponent', () => {
  let component: ListBusDetailComponent;
  let fixture: ComponentFixture<ListBusDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListBusDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListBusDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
