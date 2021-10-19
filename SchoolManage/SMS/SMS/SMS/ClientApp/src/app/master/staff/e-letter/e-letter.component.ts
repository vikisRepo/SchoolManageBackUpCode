import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators,NgForm  } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { StaffrestApiService } from '../staffrest-api.service';
import { ActivatedRoute } from '@angular/router';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { FactorydataService } from 'src/app/shared/factorydata.service';
import { MatDialog } from '@angular/material/dialog';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';
import { HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-e-letter',
  templateUrl: './e-letter.component.html',
  styleUrls: ['./e-letter.component.css']
})
export class ELetterComponent implements OnInit,FormTouched {
  eletterfrm : FormGroup;
  letterTypes = SmsConstant.letterType;
  employeeid = SmsConstant.employeeId;
  month = SmsConstant.months;
  years = SmsConstant.year;
  isAddMode?: boolean;
  departmentName : any;
  teacherId : any;
  staffName : any;
  disableTeacherDetails : boolean;
  loading = false;
  submitted = false;
  id?: any;
  file : any;

   @BlockUI() blockUI: NgBlockUI;

  constructor( private fb:FormBuilder, private staffrestApiService :StaffrestApiService, public factory :FactorydataService,private route: ActivatedRoute, public dialog: MatDialog) {
      this.eletterfrm = this.fb.group({
        empid: ['', [Validators.required]],
        staffName:['', Validators.required],
        letterType:['',Validators.required],
        department:['', Validators.required],
        month:[, Validators.required],
        teacherId:['',Validators.required],
        year:[, Validators.required],
        attachment: ['',Validators.required]
      });

   }
  formTouched(): boolean {
    this.eletterfrm.markAllAsTouched();
    return this.eletterfrm.valid;
  }


   ngAfterViewInit(): void {

    if(!this.isAddMode)
    {
      this.staffrestApiService.getStaffeLetter(this.id)
        .subscribe(data => {
          this.eletterfrm.patchValue(data);
        }, error => console.log(error));
    }
    
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;
  }

  empidchange(empdetail : any): void {
    console.log(empdetail);
    let _empDetails = this.factory.employeeId;
    for (let i = 0; i < this.factory.employeeId.length; i++) {
      if(this.factory.employeeId[i].employeeId == empdetail.value)
      {
        this.departmentName = this.factory.employeeId[i].departmentName;
        this.teacherId = this.factory.employeeId[i].teacherId;
        this.staffName = this.factory.employeeId[i].staffName;
        this.disableTeacherDetails = true;
      }
    }
  }

  submit() {
    this.eletterfrm.markAllAsTouched();
    if (this.eletterfrm.invalid) {
      // this.router.navigate([this.returnUrl]);
      return;

    }

    this.blockUI.start();
    this.submitted = true;

    if (this.isAddMode) {
      this.createStaffeLetter();
     } else {
      this.updateSatffeLetter();
     }

     this.blockUI.stop();


    
  }

  onFormSubmit(form:NgForm)  
  {  
    console.log(form);  
  }  


  createStaffeLetter()
  {

    this.staffrestApiService.createStaffeLetter(this.file,this.eletterfrm.value).toPromise().then(      
      data => {
        if (data) {
          switch (data.type) {
            case HttpEventType.UploadProgress:
              // this.uploadStatus.emit( {status: ProgressStatusEnum.IN_PROGRESS, percentage: Math.round((data.loaded / data.total) * 100)});
              break;
            case HttpEventType.Response:
              // this.inputFile.nativeElement.value = '';
              // this.uploadStatus.emit( {status: ProgressStatusEnum.COMPLETE});
              break;
          }
        }
        this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"Staff Feedback created successfully !"});
        setTimeout(() => {
          this.dialog.closeAll();
          this.router.navigate(['/staff-feedback-list']);
        }, 2500);
      },
      error => {
        // this.inputFile.nativeElement.value = '';
        // this.uploadStatus.emit({status: ProgressStatusEnum.ERROR});
      }
    );
    this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"e-Letter detail created successfully !"});
    setTimeout(() => {
      this.dialog.closeAll();
    }, 2500);
  }

  updateSatffeLetter()
  {
    this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"e-Letter detail updated successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500);
    this.staffrestApiService.updateStaffeLetter(this.id, this.eletterfrm.value).subscribe(_=>{
      this.staffrestApiService.createStaffeLetter(this.eletterfrm.value).subscribe(_=>{
       
        
        
      });
    });
  }
  onSubmit() {

    this.submitted = true;
    // stop here if form is invalid    
  }
  public upload(event) {
    if (event.target.files && event.target.files.length > 0) {
      this.file = event.target.files[0];
      
    }
  }

  get f() { return this.eletterfrm.controls; }
   
}
