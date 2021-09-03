import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InventoryDefectComponent } from './inventory-defect.component';

describe('InventoryDefectComponent', () => {
  let component: InventoryDefectComponent;
  let fixture: ComponentFixture<InventoryDefectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InventoryDefectComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InventoryDefectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
