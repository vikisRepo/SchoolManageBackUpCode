import { Component, OnInit, Output, EventEmitter, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AnyRecord } from 'dns';
import { FileDetector } from 'selenium-webdriver';
import { SmsConstant } from 'src/app/shared/constant-values';
import { FactorydataService } from 'src/app/shared/factorydata.service';
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
  ALL_Section: any = [];

  @ViewChild('dt') addressDt: FormTouched;

  constructor(private fb: FormBuilder, private factory: FactorydataService) {
      this.blood = factory.bloods;
      this.salutations = factory.salutations;
      this.maritalstatus = factory.maritalStatus;
      this.religion = factory.religion;
      this.gender = factory.gender;
      this.nationality = factory.nationality;
      this.motherTon = factory.motherTongue;
      //debugger;
      this.languageknown = factory.language;
      this.firstLang = factory.language;
      this.secndLanguage = factory.language;
      this.class = factory.classes;
      this.studentProfileForm = this.fb.group({
        salutation: ['',Validators.required]
      , firstName: [,[Validators.required, Validators.pattern('^[a-zA-Z ]*$')]]
      , middleName: ['']
      , lastName:  [, [Validators.required, Validators.pattern('^[a-zA-Z ]*$')]]
      , dob: ['',Validators.required]
      , bloodGroup: [0,Validators.required]
      , nationalityId: [0,Validators.required]
      , religionId: [0,Validators.required]
      , gender: [0,Validators.required]
      , emailId: ['', [Validators.required, Validators.email]]
      , aadharNumber: [, [Validators.required, Validators.maxLength(12),Validators.minLength(12), Validators.pattern(/^[0-9]\d*$/)]]
      , mobile: ['', [Validators.required, Validators.maxLength(10), Validators.pattern(/^[0-9]\d*$/)]]
      , admissionNumber: ['',[Validators.required,Validators.pattern(/^[a-zA-Z0-9_]*$/)]]
      , admissionDate: ['',Validators.required]
      , class: ['',Validators.required]
      , section: ['',Validators.required]
      , rollNo: ['',Validators.required]
      , firstLanguage: ['',Validators.required]
      , secondLanguage: ['',Validators.required]
      , emisNumber: ['',Validators.required]
      , schoolName: ['']
      , schoolBrand: [0]
      , passingOutSchool: [0]
      , yearofattendence: [0]
      , academicPrecentage: ['',[Validators.pattern(/^[0-9]\d*$/)]]
      , reasonForLeaving: ['']
    });

    this.studentProfileForm.valueChanges.subscribe(() => {
      Object.assign(this.formValues, this.studentProfileForm.value);
      this.factory.GetSectionByClassName(this.studentProfileForm.value['class']).subscribe((data) => {
        this.ALL_Section = data; 
      });
      this.stuFormtDetails.emit({ value: this.formValues, valid: (this.studentProfileForm.valid && this.addressValidFlag) }); // 

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

  LoadSections(className)
  {
    this.factory.GetSectionByClassName(className.value).subscribe((data) => {
      this.ALL_Section = data; 
    });
  }

}
