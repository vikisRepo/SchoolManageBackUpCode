import { Component, Input, OnInit, EventEmitter, OnChanges, Output, SimpleChanges } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { SmsConstant } from '../../constant-values';
import { FormTouched } from '../../interfaces/form-touched';

@Component({
  selector: 'app-address-detail',
  templateUrl: './address-detail.component.html',
  styleUrls: ['./address-detail.component.css']
})
export class AddressDetailComponent implements OnInit, OnChanges, FormTouched {

  @Input('title') addressLabel = '';
  // to show checkbox 
  @Input() pFlag = false;
  @Input() formInput = {};
  @Output() formValue = new EventEmitter<any>();
  @Output() pFlagEmit = new EventEmitter<boolean>();

  form: FormGroup;
  city = SmsConstant.city;
  state = SmsConstant.state;
  country = SmsConstant.country;

  constructor(fb: FormBuilder) {
    this.form = fb.group(
      {
        "line1": ['', [Validators.required, Validators.maxLength(30)]],
        "line2": ['', [Validators.required, Validators.maxLength(30)]],
        "line3": ['', Validators.maxLength(30)],
        "city": ['', [Validators.required, Validators.maxLength(30)]],
        "sate": ['', [Validators.required, Validators.maxLength(30)]],
        "country": ['', [Validators.required, Validators.maxLength(30)]],
        "pincode": ['', [Validators.required, Validators.maxLength(30)]]
      });

    this.form.valueChanges.subscribe(() => {
      this.formValue.emit({ value: this.form.value, valid: this.form.valid });
    });

  }


  formTouched() {
    this.form.markAllAsTouched();
    return this.pFlag ? true : this.form.valid;
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.formInput) {
      this.form.patchValue(this.formInput);
    }
  }


  ngOnInit(): void {
  }

  checkBoxAction(matValue: any) {
    this.pFlagEmit.emit(matValue.checked);
    if (matValue.checked) {
      this.form.disable();
    }
    else {
      this.form.enable();
    }
  }

}
