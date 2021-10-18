import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router'
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Subscription} from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { StaffrestApiService } from '../staffrest-api.service';
import { SmsConstant } from 'src/app/shared/constant-values';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-staff-feedback-list',
  templateUrl: './staff-feedback-list.component.html',
  styleUrls: ['./staff-feedback-list.component.css']
})
export class StaffFeedbackListComponent implements OnInit {
  // staffFeedbackList = [
  //   {
  //     'staffName': 'arya',
  //     'feedBackType': 'Achievement',
  //     'feedbackTitle':'Best Teacher of the Year',
  //     'description':'2020 Best Techer BVPS',
  //     'date':'06-02-2021',
  //     'attachment':'A1'
  //   }
  // ];

  staffFeedbackList: any;
  staffFeedbackArr: Array<any>;

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;
  currentUserSubscription !: Subscription;
  staffListData!: MatTableDataSource<any>;
  feedbackTypes = SmsConstant.feedbackTypes;
  stafffeedbackfilters: FormGroup;
  filters : boolean;
  isMyFeedbackMode : boolean;
  rows :  Number = 0;
  id : any;
  range =new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  })
   @BlockUI() blockUI: NgBlockUI;

  columnsToDisplay = ['staffName', 'feedBackType', 'feedbackTitle', 'description', 'date', 'attachment', 'actions'];
  constructor(private fb: FormBuilder,private router: Router,  private staffrestApiService :StaffrestApiService,
    public dialog: MatDialog, private route: ActivatedRoute) { 
      this.stafffeedbackfilters = this.fb.group({
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
    if (!this.isMyFeedbackMode) {
      this.LoadFeedBackbyAccount();
    }
    else {
      this.LoadFeedBack();
    }
  }

  callNewStaffFeedback()
  {
    this.router.navigate(['staff-feedback'])
  }

  removeStaffFeedBack(staff : any){

    this.staffrestApiService.deleteStaffFeedBack(staff.empid).subscribe(_=>{
      this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"Staff Feedback deleted successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500); 
      if (!this.isMyFeedbackMode) {
        this.LoadFeedBackbyAccount();
      }
      else {
        this.LoadFeedBack();
      }
    });
  }

  editStaffFeedBack(staff : any)
  {
    this.router.navigate(['staff-feedback',staff.staffFeedbackID]);
    // this.staffApiService.deleteStaff(staff.mobile).subscribe(_=>{
    // });
  }

  applyFilterDate(event: any) {
    /* const filterValues = {
       Class: this.studentfilters.value["classFilter"].toLowerCase()
     };
    
     this.studentListData.filter = filterValues;*/
    //  console.log("StartDate" + this.studentfeedbackfilters.value["start"]);
    //  console.log("EndDate" + this.studentfeedbackfilters.value["end"]);
    //  debugger;
     let filterData=this.staffFeedbackArr.filter(obj=> obj.date >= this.stafffeedbackfilters.value["start"].toISOString()
     && obj.date <= this.stafffeedbackfilters.value["end"].toISOString());
     this.staffFeedbackList = new MatTableDataSource(filterData);
    this.rows = this.staffFeedbackList.data.length;
   }

  LoadFeedBack()
  {
    this.blockUI.start();

    this.currentUserSubscription = this.staffrestApiService.getStaffsFeedBack().subscribe((staffFeedback:any) => {
      this.staffFeedbackArr = staffFeedback;
      this.staffFeedbackList = staffFeedback;
      this.rows = this.staffFeedbackArr.length;
      console.log(this.staffFeedbackList);
       this.blockUI.stop();

    });
  }

  LoadFeedBackbyAccount()
  {
    this.blockUI.start();

    this.currentUserSubscription = this.staffrestApiService.getStaffsFeedBackByAccount(this.id).
    subscribe((staffFeedback:any) => {
      this.staffFeedbackArr = staffFeedback;
      this.staffFeedbackList = staffFeedback;
      this.rows = this.staffFeedbackArr.length;
      console.log(this.staffFeedbackList);
       this.blockUI.stop();

    });
  }


  filterToggle(){
    this.filters = !this.filters;
  }

  applyFilterFeedbackType(event : any){
    debugger;
    let filterData =this.staffFeedbackArr.filter(obj => obj.feedbackType===this.stafffeedbackfilters.value["FeedbackTypeFilter"]);
    this.staffFeedbackList = new MatTableDataSource(filterData);
    this.rows = this.staffFeedbackList.data.length;
  }

  clearFilter():void{
    this.staffFeedbackList.filter = '';
    this.stafffeedbackfilters.reset();
    if (!this.isMyFeedbackMode)
    {
       this.LoadFeedBackbyAccount();
    }
    else
    {
       this.LoadFeedBack();
    }
  }

}
