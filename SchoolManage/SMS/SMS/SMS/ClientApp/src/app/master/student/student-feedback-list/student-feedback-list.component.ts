import { Component, OnInit,  ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { StudentrestApiService } from '../studentrest-api.service';
import { Subscription} from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { FormBuilder, FormControl,FormGroup } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';

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
    rows : number =0;

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
  
  constructor(private fb: FormBuilder,private roter:Router, private studentrestApiService :StudentrestApiService) { 
    this.studentfeedbackfilters = this.fb.group({
      FeedbackTypeFilter: [''],
      start: [''],
      end:['']
    });
  }

  ngOnInit(): void {
    this.LoadFeedBack();
  }
  callNewStudentFeedback(){
    this.roter.navigate(['/student-feedback'])
  }

  removeStaffFeedBack(staff : any){

    this.studentrestApiService.deleteStudentFeedBack(staff.studentFeedbackId).subscribe(_=>{
      this.LoadFeedBack();
    });
  }

  editStaffFeedBack(staff : any)
  {
    console.log(staff);
    this.roter.navigate(['/main/student-feedback',staff.studentFeedbackId]);
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
      this.rows = this.studentFeedbackList.data.length;
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
    debugger;
    let filterData =this.studentFeedbackArr.filter(obj => obj.feedbackType===this.studentfeedbackfilters["FeedbackTypeFilter"]);
    console.log(this.studentfeedbackfilters["FeedbackTypeFilter"]);
    this.studentFeedbackList = new MatTableDataSource(filterData);
   // this.rows = this.studentFeedbackList.data.length;
  }

  applyFilterDate(event: any) {
    /* const filterValues = {
       Class: this.studentfilters.value["classFilter"].toLowerCase()
     };
     debugger;
     this.studentListData.filter = filterValues;*/
     let fileterData=this.studentFeedbackArr.filter(obj=> obj.date===this.studentfeedbackfilters["start"].value);
     this.studentFeedbackList=new MatTableDataSource(fileterData);
     this.rows = this.studentFeedbackList.data.length;
   }

  clearFilter():void{
    this.studentFeedbackList.filter = '';
    this.studentfeedbackfilters.reset();
    this.LoadFeedBack();
  }

}
