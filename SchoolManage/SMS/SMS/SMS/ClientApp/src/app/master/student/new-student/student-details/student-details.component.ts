import { Component, OnInit, Output, EventEmitter, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})
export class StudentDetailsComponent implements OnInit ,FormTouched{
  @Output() stuFormtDetails = new EventEmitter();
  @Input() getFormValues = {};
  studentProfileForm: FormGroup;
  formValues = { addresses: [] };//refer to student details parameters
  addressValidFlag: boolean = false;
  blood = SmsConstant.bloods;
  salutations =SmsConstant.salutations;
  maritalstatus =SmsConstant.maritalStatus;
  religion =SmsConstant.religion;
  gender = SmsConstant.gender;
  nationality = SmsConstant.nationality;
  motherTon = SmsConstant.motherTongue;
  languageknown = SmsConstant.languageKnown;
  class = SmsConstant.classes
  firstLang =SmsConstant.firstLanguage;
  secndLanguage =SmsConstant.secondLanguage;
  section =SmsConstant.section;
  sclBrand =SmsConstant.schoolBrand;
  pasOutScl =SmsConstant.passingOutSchool;
  yearOfAttends =SmsConstant.yearOfAttendence;
  addressData = null;

  @ViewChild('dt') addressDt: FormTouched;

  constructor(private fb: FormBuilder) {
    this.studentProfileForm = this.fb.group({
        salutation: ['',Validators.required]
      , firstName: [,[Validators.required, Validators.pattern('^[a-zA-Z ]*$')]]
      , middleName: ['']
      , lastName:  [, [Validators.required, Validators.pattern('^[a-zA-Z ]*$')]]
      , dob: ['',Validators.required]
      , bloodGroup: ['',Validators.required]
      , nationalityId: ['',Validators.required]
      , religionId: ['',Validators.required]
      , gender: ['',Validators.required]
      , emailId: ['', [Validators.required, Validators.email]]
      , aadharNumber: [, [Validators.required, Validators.maxLength(12),Validators.minLength(12), Validators.pattern(/^[0-9]\d*$/)]]
      , mobile: [, [Validators.required, Validators.maxLength(10), Validators.pattern(/^[0-9]\d*$/)]]
      , admissionNumber: ['',Validators.required]
      , admissionDate: ['',Validators.required]
      , class: ['',Validators.required]
      , section: ['',Validators.required]
      , rollNo: ['',Validators.required]
      , firstLanguage: ['',Validators.required]
      , secondLanguage: ['',Validators.required]
      , emisNumber: ['',Validators.required]
      , schoolName: ['',Validators.required]
      , schoolBrand: ['',Validators.required]
      , passingOutSchool: ['',Validators.required]
      , yearofattendence: ['',Validators.required]
      , academicPrecentage: ['',Validators.required]
      , reasonForLeaving: ['',Validators.required]
      
    });

    this.studentProfileForm.valueChanges.subscribe(() => {
      Object.assign(this.formValues, this.studentProfileForm.value);
      this.stuFormtDetails.emit({ value: this.formValues, valid: (this.studentProfileForm.valid && this.addressValidFlag) });

    })
    
  }
  formTouched(): boolean {
    this.studentProfileForm.markAllAsTouched();

    let ft = this.addressDt.formTouched();
    console.log(this.studentProfileForm.status)
    return this.studentProfileForm.valid && ft;
  }
  ngOnChanges(changes: SimpleChanges): void {
  
    if (changes.getFormValues.currentValue)
    {
      this.addressData=this.getFormValues["addresses"];
      this.studentProfileForm.patchValue(this.getFormValues);
    }
  }
  onSubmit() {
    console.warn(this.studentProfileForm.value);
  }

  ngOnInit(): void {
  }

        // convenience getter for easy access to form fields
        get f() { return this.studentProfileForm.controls; }
  getAddress(arrValue: any) {
    let value = Array.from(arrValue, (obj: any) => obj.value) as never[];
    this.formValues.addresses = value;
    this.addressValidFlag = !((Array.from(arrValue, (obj: any) => obj.valid)).includes(false));
    this.stuFormtDetails.emit({ value: this.formValues, valid: (this.studentProfileForm.valid && this.addressValidFlag) });
  }


}
