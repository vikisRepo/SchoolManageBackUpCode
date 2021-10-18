import { Component, OnInit,  ViewChild, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentrestApiService } from '../studentrest-api.service';
import { Subscription} from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { FormBuilder, FormControl,FormGroup } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-student-feedback-list',
  templateUrl: './student-feedback-list.component.html',
  styleUrls: ['./student-feedback-list.component.css']
})
export class StudentFeedbackListComponent implements OnInit {
  studentFeedbackList : any;
  studentFeedbackArr: Array<any>;

    @ViewChild(MatPaginator)
    paginator!: MatPaginator;
    @ViewChild(MatSort) sort !: MatSort;
  
    currentUserSubscription !: Subscription;
    staffListData: MatTableDataSource<any>;
    feedbackTypes = SmsConstant.feedbackTypes;
    studentfeedbackfilters: FormGroup;
    filters : boolean;
    rows : number;
    id : string;
    isMyFeedbackMode : boolean;

    // "studentFeedbackId": 1,
    // "staffName": "asdasdasd",
    // "feedbackType": "1",
    // "date": "2021-02-28T18:30:00",
    // "class": "asdasd",
    // "feedbacktitle": "asdasd",
    // "section": "asdasd",
    // "teacherId": "",
    // "description": "asdasdasd",
    // "attachment": ""
  
    range = new FormGroup({
      start: new FormControl(),
      end: new FormControl()
    });
     @BlockUI() blockUI: NgBlockUI;
    columnsToDisplay=['studentName','feedBackType','feedbackTitle','description','date','attachment', 'actions'];
  
  constructor(private fb: FormBuilder,private studentrestApiService :StudentrestApiService,
    private route: ActivatedRoute, public dialog: MatDialog,
    private router: Router) { 
    this.studentfeedbackfilters = this.fb.group({
      FeedbackTypeFilter: [''],
      // range: this.fb.group({
      start: [''],
      end:[''],
      filterdate: [{begin: new Date(2018, 7, 5), end: new Date(2018, 7, 25)}]
    });
  }

  ngOnInit(): void {
    debugger;
    this.id = this.route.snapshot.params['id'];
    this.isMyFeedbackMode = !this.id;
    if (!this.isMyFeedbackMode)
    {
       this.LoadFeedBackByAdmissionNumber();
    }
    else
    {
       this.LoadFeedBack();
    }
  }
  callNewStudentFeedback(){
    this.router.navigate(['/student-feedback'])
  }

  removeStaffFeedBack(staff : any){

    this.studentrestApiService.deleteStudentFeedBack(staff.studentFeedbackId).subscribe(_=>{
      this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"Student Feedback deleted successfully !"});
        setTimeout(() => {
          this.dialog.closeAll();
        }, 2500);
      this.LoadFeedBack();
    });
  }

  editStaffFeedBack(staff : any)
  {
    console.log(staff);
    this.router.navigate(['/student-feedback',staff.studentFeedbackId]);
    // this.staffApiService.deleteStaff(staff.mobile).subscribe(_=>{
    // });
  }

  LoadFeedBack()
  {
    this.blockUI.start();

    this.currentUserSubscription = this.studentrestApiService.getStudentsFeedBack().subscribe((staffFeedback:any) => {
      this.studentFeedbackArr = staffFeedback;
      this.studentFeedbackList = staffFeedback;
      console.log(this.studentFeedbackList);
      this.rows = this.studentFeedbackArr.length;
      this.blockUI.stop();

    });
  }

  LoadFeedBackByAdmissionNumber()
  {
    this.blockUI.start();

    this.currentUserSubscription = this.studentrestApiService.getStudentsFeedBackByAdmissionNumber(this.id).subscribe((staffFeedback:any) => {
      this.studentFeedbackArr = staffFeedback;
      this.studentFeedbackList = staffFeedback;
      console.log(this.studentFeedbackList);
      this.rows = this.studentFeedbackArr.length;
       this.blockUI.stop();
    });
  }

  filterToggle(){
    this.filters = !this.filters;
  }
  // applyFilter(event: any) {
  //   const filterValue = this.studentfeedbackfilters.value[event];
  //   this.studentFeedbackList.filter = filterValue.trim().toLowerCase();
  // }
  
  applyFilterFeedbackType(event : any){
    // debugger;
    let filterData =this.studentFeedbackArr.filter(obj => obj.feedbackType===this.studentfeedbackfilters.value["FeedbackTypeFilter"]);
    console.log(this.studentfeedbackfilters["FeedbackTypeFilter"]);
    this.studentFeedbackList = new MatTableDataSource(filterData);
    this.rows = this.studentFeedbackList.data.length;
  }

  applyFilterDate(event: any) {
    /* const filterValues = {
       Class: this.studentfilters.value["classFilter"].toLowerCase()
     };
    
     this.studentListData.filter = filterValues;*/
    //  console.log("StartDate" + this.studentfeedbackfilters.value["start"]);
    //  console.log("EndDate" + this.studentfeedbackfilters.value["end"]);
    //  debugger;
     let fileterData=this.studentFeedbackArr.filter(obj=> obj.date >= this.studentfeedbackfilters.value["start"].toISOString()
     && obj.date <= this.studentfeedbackfilters.value["end"].toISOString());
     this.studentFeedbackList=new MatTableDataSource(fileterData);
     this.rows = this.studentFeedbackList.data.length;
   }

  clearFilter():void{
    this.studentFeedbackList.filter = '';
    this.studentfeedbackfilters.reset();
    if (!this.isMyFeedbackMode)
    {
       this.LoadFeedBackByAdmissionNumber();
    }
    else
    {
       this.LoadFeedBack();
    }
  }

}
