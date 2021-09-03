import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { StaffrestApiService } from '../staffrest-api.service';
import { ActivatedRoute } from '@angular/router';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { MatDialog } from '@angular/material/dialog';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { Console } from 'console';


@Component({
  selector: 'app-staff-feedback',
  templateUrl: './staff-feedback.component.html',
  styleUrls: ['./staff-feedback.component.css']
})
export class StaffFeedbackComponent implements OnInit {
  newstaffFeedback: FormGroup;
  feedbackTypes = SmsConstant.feedbackTypes;
  isAddMode?: boolean;
  loading = false;
  submitted = false;
  id?: any;

   @BlockUI() blockUI: NgBlockUI;

  // staffFeedbackTitle = SmsConstant.feedbackTitles;
  constructor(private fb: FormBuilder, private staffrestApiService :StaffrestApiService, private route: ActivatedRoute,public dialog: MatDialog) {
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
          this.blockUI.stop();
        }, error => console.log(error));
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
    this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"Staff Feedback created successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500); 
    this.staffrestApiService.createStaffFeedBack(this.newstaffFeedback.value).subscribe(_=>{
    });
    console.log(this.newstaffFeedback.value);
  }

  updateSatfffeedback()
  {
    this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"Staff Feedback updated successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500); 
    this.staffrestApiService.updateStaffFeedBack(this.id, this.newstaffFeedback.value).subscribe(_=>{

    });
  }

}
