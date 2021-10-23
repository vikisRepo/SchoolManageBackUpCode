import { Component, OnInit, ViewChild, AfterViewInit  } from '@angular/core';
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
  selector: 'app-e-letter-list',
  templateUrl: './e-letter-list.component.html',
  styleUrls: ['./e-letter-list.component.css']
})
export class ELetterListComponent implements OnInit {

  // eLetterList = [
  //   {
  //     'staffName': 'hai',
  //     'employeeID': 'hai',
  //     'letterType': 1,
  //     'month': 'hai',
  //     'year': 'hai',
  //     'attachment': 'hai'
  //   },
  //   {
  //     'staffName': 'hai',
  //     'employeeID': 'hai',
  //     'letterType': 1,
  //     'month': 'hai',
  //     'year': 'hai',
  //     'attachment': 'hai'
  //   }
  // ];


  eLetterList: any[];
  //  Staff Type Employee ID Teacher ID Department Designation Status Joining Date Mobile Number e-mail
  columnsToDisplay = ['staffName', 'employeeID', 'letterType', 'month', 'year', 'actions'];
  
  letterType = SmsConstant.letterType;
  monthList = SmsConstant.months;
  years = SmsConstant.year;
  filters : boolean = false;
  rows : number = 0;
  id : any;
  isMyeLetterMode : boolean;
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

  currentUserSubscription !: Subscription;
  staffListData!: MatTableDataSource<any>;
  eletterfilters: FormGroup;
  
   @BlockUI() blockUI: NgBlockUI;

  constructor(private fb: FormBuilder,private router: Router, private staffrestApiService :StaffrestApiService,private route: ActivatedRoute, public dialog: MatDialog) { 
    this.eletterfilters = this.fb.group({
      leavetypeFilter: [''],
      monthFilter: [''],
      yearfilter: [''],
      joiningDateFrom: ['']
    });

  }
  // name = new FormControl('');

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.isMyeLetterMode = !this.id;
    if(!this.isMyeLetterMode){
      this.LoadeLetterbyAccount();
    }
    else{
      this.LoadeLetter();
    }
  }

  filterToggle()
  {
    this.filters = !this.filters;
  }

  callNewELetter() {

    this.router.navigate(['/e-letter']);
  }
  
  removeStaffeLetter(staff : any)
  { 
    // this.LoadeLetter();
    // this.staffrestApiService.deleteStaffeLetter(staff.empid).subscribe(_=>{
    //   this.LoadeLetter();
    // });
    this.staffrestApiService.deleteStaffeLetter(staff.empid).subscribe(_=>{
      this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"Staff Feedback deleted successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500); 
      if (!this.isMyeLetterMode) {
        this.LoadeLetterbyAccount();
      }
      else {
        this.LoadeLetter();
      }
    });
  }

  editStaffeLetter(staff : any)
  {
    this.router.navigate(['/e-letter',staff.staffeLetterId,this.isMyeLetterMode]);
    // this.staffApiService.deleteStaff(staff.mobile).subscribe(_=>{
    // });
  }

  applyFilter(event: any) {
    console.log(event)
  
    const filterValue = this.eletterfilters.value[event];
    this.eLetterList.filter = filterValue.trim().toLowerCase();
  }

  LoadeLetter()
  {
    this.blockUI.start();

    this.currentUserSubscription = this.staffrestApiService.getStaffseLetters().subscribe((staffeLetter:any) => {
      this.eLetterList = staffeLetter;
      console.log(this.eLetterList);
       this.blockUI.stop();

    });
  }
  LoadeLetterbyAccount()
  {
    debugger;
    this.blockUI.start();

    this.currentUserSubscription = this.staffrestApiService.getStaffseLetterkByAccount(this.id).
    subscribe((staffeLeter:any) => {
      this.eLetterList = staffeLeter;
      console.log(this.eLetterList);
       this.blockUI.stop();

    });
  }

}

