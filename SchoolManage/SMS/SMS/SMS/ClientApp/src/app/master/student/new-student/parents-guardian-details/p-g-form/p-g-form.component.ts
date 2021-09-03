import { Component, EventEmitter, Input, OnInit, Output, SimpleChange } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormGroup, FormBuilder, Validator, FormControl } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';

@Component({
  selector: 'app-p-g-form',
  templateUrl: './p-g-form.component.html',
  styleUrls: ['./p-g-form.component.css']
})
export class PGFormComponent implements OnInit, FormTouched {

  @Input() titleLabel: string = '';
  @Input() pFlag = false;
  @Input() formInput = {};
  @Output() formValue = new EventEmitter<any>();
  @Output() pflagEmit = new EventEmitter<boolean>();
  parents: FormGroup;
  salutations = SmsConstant.salutations;
  constructor(private fb: FormBuilder) {
    this.parents = fb.group({
      salutation: ['', Validators.required]
      , firstName: ['', Validators.required]
      , middleName: ['', Validators.required]
      , lastName: ['', Validators.required]
      , mobileNumber: ['0', Validators.required]
      , occupation: ['', Validators.required]
      , email: ['', Validators.required]
      , aadharNumber: ['', Validators.required]
      , company: ['', Validators.required]
      , designation: ['', Validators.required]
      , annualIncome: ['0', Validators.required]
      , bvEmployee: [true]
    });

    this.parents.valueChanges.subscribe(() => {
      this.formValue.emit({
        value: this.parents.value, valid: this.parents.valid
      })
    });
  }
  formTouched(): boolean {

    this.parents.markAllAsTouched();
    return this.parents.disabled ? true : this.parents.valid;
  }

  ngOnInit(): void {
  }

  toggle() {

    if (this.parents.disabled) {
      this.parents.enable();
      return;
    }
    // this.parents.reset();
    this.parents.disable();
  }

}
