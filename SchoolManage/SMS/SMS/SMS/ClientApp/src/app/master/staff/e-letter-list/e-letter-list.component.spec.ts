import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ELetterListComponent } from './e-letter-list.component';

describe('ELetterListComponent', () => {
  let component: ELetterListComponent;
  let fixture: ComponentFixture<ELetterListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ELetterListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ELetterListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
