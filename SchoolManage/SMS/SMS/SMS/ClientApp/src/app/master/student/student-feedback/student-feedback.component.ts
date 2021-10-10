import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { ActivatedRoute } from '@angular/router';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { StudentrestApiService } from '../studentrest-api.service';
import { MatDialog } from '@angular/material/dialog';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { FactorydataService } from 'src/app/shared/factorydata.service';
import { HttpEventType } from '@angular/common/http';

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
  file : any;


   @BlockUI() blockUI: NgBlockUI;
  // studentFeedbackTitle = SmsConstant.feedbackTitles;
  constructor(private fb:FormBuilder,  private studentrestApiService :StudentrestApiService, private route: ActivatedRoute,public dialog: MatDialog,  private factory: FactorydataService) 
  {
    debugger;
    this.classes =factory.classes;
    this.staffNameList =factory.staffNames;
    this.newstudentFeedback=this.fb.group({
      admissionNumber: ['', Validators.required],
      staffId: ['', Validators.required],
      feedbackType: ['', Validators.required],
      startDate: ['', Validators.required],
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
    debugger;
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
    this.studentrestApiService.createStudentFeedBack(this.file, this.newstudentFeedback.value).toPromise().then(
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
        this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"Student feedback created successfully !"});
        setTimeout(() => {
          this.dialog.closeAll();
        }, 2500);
      },
      error => {
        // this.inputFile.nativeElement.value = '';
        // this.uploadStatus.emit({status: ProgressStatusEnum.ERROR});
      }
    );
  }

  public upload(event) {
    if (event.target.files && event.target.files.length > 0) {
      this.file = event.target.files[0];
      
    }
  }

  updateStudenteLetter()
  {
    this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"Student feedback updated successfully !"});
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
