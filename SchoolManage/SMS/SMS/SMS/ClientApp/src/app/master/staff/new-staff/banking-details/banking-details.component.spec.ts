import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BankingDetailsComponent } from './banking-details.component';

describe('BankingDetailsComponent', () => {
  let component: BankingDetailsComponent;
  let fixture: ComponentFixture<BankingDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BankingDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BankingDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
