import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ELetterComponent } from './e-letter.component';

describe('ELetterComponent', () => {
  let component: ELetterComponent;
  let fixture: ComponentFixture<ELetterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ELetterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ELetterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
