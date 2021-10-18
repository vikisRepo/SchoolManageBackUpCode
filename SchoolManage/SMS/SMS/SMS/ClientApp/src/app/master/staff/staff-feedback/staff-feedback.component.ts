import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { StaffrestApiService } from '../staffrest-api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { MatDialog } from '@angular/material/dialog';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { Console } from 'console';
import { FactorydataService } from 'src/app/shared/factorydata.service';
import { HttpEventType } from '@angular/common/http';


@Component({
  selector: 'app-staff-feedback',
  templateUrl: './staff-feedback.component.html',
  styleUrls: ['./staff-feedback.component.css']
})
export class StaffFeedbackComponent implements OnInit {
  newstaffFeedback: FormGroup;
  employeeid = SmsConstant.employeeId;
  feedbackTypes = SmsConstant.feedbackTypes;
  isAddMode?: boolean;
  loading = false;
  submitted = false;
  id?: any;
  departmentName : any;
  teacherId : any;
  staffName : any;
  disableTeacherDetails : boolean;
  file : any;

   @BlockUI() blockUI: NgBlockUI;

  // staffFeedbackTitle = SmsConstant.feedbackTitles;
  constructor(private fb: FormBuilder, private staffrestApiService :StaffrestApiService, private route: ActivatedRoute,
    public dialog: MatDialog, public factory :FactorydataService, private router: Router) {
  this.disableTeacherDetails = false;  
  this.employeeid = this.factory.employeeId;

    this.newstaffFeedback = this.fb.group({
      empid: ['', Validators.required],
      staffName: ['', Validators.required],
      feedbackType: ['',Validators.required],
      date: ['',Validators.required],
      department: ['',Validators.required],
      feedbacktitle: ['',Validators.required],
      teacherId: ['',Validators.required],
      description:['',Validators.required],
      attachment: ['',Validators.required]
    });
  }

  ngAfterViewInit(): void {
    
    if(!this.isAddMode)
    {
      
      this.blockUI.start();
      this.staffrestApiService.getStaffFeedBack(this.id)
        .subscribe(data => {
          this.newstaffFeedback.patchValue(data);
          this.disableTeacherDetails = true;
          this.blockUI.stop();
        }, error => console.log(error));
    }
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

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;
  }

  submit() {
    console.log(this.newstaffFeedback.value);
    this.newstaffFeedback.markAllAsTouched();
    this.blockUI.start();
    this.submitted = true;

    if (this.isAddMode) {
      this.createStaffFeedback();
     } else {
      this.updateSatfffeedback();
     }

     this.blockUI.stop();
    
  }

  createStaffFeedback()
  {
    this.staffrestApiService.createStaffFeedBack(this.file, this.newstaffFeedback.value).toPromise().then(
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
  }

  updateSatfffeedback()
  {
    this.staffrestApiService.updateStaffFeedBack(this.id, this.file, this.newstaffFeedback.value).toPromise().then(_=>{
      this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"Staff Feedback updated successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
        this.router.navigate(['/staff-feedback-list']);
      }, 2500); 
    });
  }

  public upload(event) {
    if (event.target.files && event.target.files.length > 0) {
      this.file = event.target.files[0];
      
    }
  }
}
