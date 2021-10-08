import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { ActivatedRoute } from '@angular/router';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { StudentrestApiService } from '../studentrest-api.service';
import { MatDialog } from '@angular/material/dialog';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { FactorydataService } from 'src/app/shared/factorydata.service';

@Component({
  selector: 'app-student-feedback',
  templateUrl: './student-feedback.component.html',
  styleUrls: ['./student-feedback.component.css']
})
export class StudentFeedbackComponent implements OnInit{
  newstudentFeedback:FormGroup;
  feedbackTypes = SmsConstant.feedbackTypes;
  staffNameList = SmsConstant.staffName
  classes = SmsConstant.classes;
  isAddMode?: boolean;
  loading = false;
  submitted = false;
  id?: any;
  ALL_Section: any = [];
  ALL_Admission: any = [];
  _className : string;
  _section : string;


   @BlockUI() blockUI: NgBlockUI;
  // studentFeedbackTitle = SmsConstant.feedbackTitles;
  constructor(private fb:FormBuilder,  private studentrestApiService :StudentrestApiService, private route: ActivatedRoute,public dialog: MatDialog,  private factory: FactorydataService) 
  {
    debugger;
    this.classes =factory.classes;
    this.staffNameList =factory.staffNames;
    this.newstudentFeedback=this.fb.group({
      admissionNumber: ['', Validators.required],
      staffName: ['', Validators.required],
      feedbackType: ['', Validators.required],
      date: ['', Validators.required],
      class: ['', Validators.required],
      feedbacktitle: ['', Validators.required],
      section:['', Validators.required],
      //teacherId: ['', Validators.required],
      description:['', Validators.required],
      attachment: ['']
    });

   }

   ngAfterViewInit(): void {

    if(!this.isAddMode)
    {
      this.studentrestApiService.getStudentFeedBack(this.id)
        .subscribe(data => {
          this.newstudentFeedback.patchValue(data);
        }, error => console.log(error));
    }
    
  }
  
   ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;
  }

  submit() {
    console.log(this.newstudentFeedback.value);
    this.newstudentFeedback.markAllAsTouched();
    if(this.newstudentFeedback.invalid)
    {
      return 
    }
    
    this.submitted = true;
 
    if (this.isAddMode) {
      this.createStudenteLetter();
     } else {
      this.updateStudenteLetter();
     }

    
    
  }

  LoadSections(className)
  {
    debugger;
    this._className = className.value;
    this.factory.GetSectionByClassName(className.value).subscribe((data) => {
      this.ALL_Section = data; 
    });
  }

  createStudenteLetter()
  {
    this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"student feedback created successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500);
   this.blockUI.start()
    this.studentrestApiService.createStudentFeedBack(this.newstudentFeedback.value).subscribe(_=>{
      this.blockUI.stop();
      
    },()=>{
      this.blockUI.stop();
    });
  }

  updateStudenteLetter()
  {
    this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"student feedback updated successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500);
    this.blockUI.start()
    this.studentrestApiService.updateStudentFeedBack(this.id, this.newstudentFeedback.value).subscribe(_=>{
      this.blockUI.stop();
      
    },()=>{
      this.blockUI.stop();
    });
  }

  LoadadmissionNumber(section)
  {
    debugger;
     this.factory.GetAdmissionNumber(this._className,section.value).subscribe((data) => {
      this.ALL_Admission = data; 
     });
    
  }
  

}
