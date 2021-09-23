import { ViewChild } from '@angular/core';
import { Component, OnInit, Output, EventEmitter, Input, OnChanges, SimpleChanges } from '@angular/core';
import { validateBasis } from '@angular/flex-layout';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FormControl, FormGroup, FormArray } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';

@Component({
  selector: 'app-personal-details',
  templateUrl: './personal-details.component.html',
  styleUrls: ['./personal-details.component.css']
})

export class PersonalDetailsComponent implements OnInit, OnChanges, FormTouched {

  @Output() formDetails = new EventEmitter();
  @Input() getFormValues = {};
  profileForm: FormGroup;
  addressValidFlag: boolean = false;
  formValues = { addresses: [''] };
  blood = SmsConstant.bloods;
  salutations = SmsConstant.salutations;
  maritalstatus = SmsConstant.maritalStatus;
  religion = SmsConstant.religion;
  gender = SmsConstant.gender;
  nationality = SmsConstant.nationality;
  motherTon = SmsConstant.motherTongue;
  languageknown = SmsConstant.languageKnown;
  getselectdata: string;
  addressData = null;
  formBuilder: any;


  @ViewChild('dt') addressDt: FormTouched;

  // get aliases() {
  //   return this.profileForm.get('aliases') as FormArray;
  // }

  constructor(private fb: FormBuilder) {

    this.profileForm = this.fb.group(
      {
        salutationId: ['', Validators.required],
        dob: ['', Validators.required],
        religionId: ['', Validators.required],
        motherTongue: ['', Validators.required],
        firstName: [,[Validators.required, Validators.pattern('^[a-zA-Z ]*$')]],
        bloodGroup: ['', Validators.required],
        gender: ['', Validators.required],
        emailId: ['', [Validators.required, Validators.email]],
        languagesId: [[], Validators.required],
        middleName: ['',Validators.pattern('^[a-zA-Z ]*$')],
        maritalStatus: ['', Validators.required],
        nationalityId: [''],
        lastName: [, [Validators.required, Validators.pattern('^[a-zA-Z ]*$')]],
        weedingDate: [''],
        mobile: [, [Validators.required, Validators.maxLength(10), Validators.pattern(/^[0-9]\d*$/)]],
        aadharNumber: [, [Validators.required, Validators.maxLength(12),Validators.minLength(12), Validators.pattern(/^[0-9]\d*$/)]],
        fatherName: [,[Validators.required, Validators.pattern('^[a-zA-Z ]*$')]],
        motherName: [,[Validators.required, Validators.pattern('^[a-zA-Z ]*$')]],
        spouseName: [, Validators.pattern('^[a-zA-Z ]*$')],
        fatherOccupation: [, Validators.pattern('^[a-zA-Z ]*$')],
        motherOccupation: [, Validators.pattern('^[a-zA-Z ]*$')],
        souseOccupation: [, Validators.pattern('^[a-zA-Z ]*$')],
        fatherMobileNumber: [, [Validators.maxLength(9), Validators.pattern(/^[0-9]\d*$/)]],
        motherMobileNumber: [, [Validators.maxLength(9), Validators.pattern(/^[0-9]\d*$/)]],
        spouseMobileNumber: [, [Validators.maxLength(9), Validators.pattern(/^[0-9]\d*$/)]],

      }
    );

    this.profileForm.valueChanges.subscribe(() => {
      Object.assign(this.formValues, this.profileForm.value);
      debugger;
      this.formValues["mobile"] = Number.parseInt(this.formValues["mobile"]);
      this.formDetails.emit({ value: this.formValues, valid: (this.profileForm.valid && this.addressValidFlag) });
    });
  }

  formTouched(): boolean {
    this.profileForm.markAllAsTouched();
  
    let ft = this.addressDt.formTouched();
    
    return this.profileForm.valid && ft;
  }

  ngOnInit(): void {

  }

      // convenience getter for easy access to form fields
      get f() { return this.profileForm.controls; }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.getFormValues.currentValue) {
      console.log(changes.getFormValues.currentValue);
      this.addressData = this.getFormValues["addresses"];
      this.getFormValues["languagesId"] = this.getFormValues["languagesId"].split(',');
      this.profileForm.patchValue(this.getFormValues);
    }
  }

  // updateProfile() {
  //   this.profileForm.patchValue({
  //     FirstName: 'Nancy',
  //     MiddleName: 'Suprise'
  //   });
  // }

  // addAlias() {
  //   this.aliases.push(this.fb.control(''));
  // }

  onSubmit() {
    // TODO: Use EventEmitter with form value
    // console.log("Hai");
    console.warn(this.profileForm.value);
  }



  getAddress(arrValue: any) {
    let value = Array.from(arrValue, (obj: any) => obj.value) as never[];
    this.formValues.addresses = value;
    this.addressValidFlag = !((Array.from(arrValue, (obj: any) => obj.valid)).includes(false));
    this.formDetails.emit({ value: this.formValues, valid: (this.profileForm.valid && this.addressValidFlag) });//
  }

}
