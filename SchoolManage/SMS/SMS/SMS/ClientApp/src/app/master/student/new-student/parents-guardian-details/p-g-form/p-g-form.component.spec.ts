import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PGFormComponent } from './p-g-form.component';

describe('PGFormComponent', () => {
  let component: PGFormComponent;
  let fixture: ComponentFixture<PGFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PGFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PGFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
