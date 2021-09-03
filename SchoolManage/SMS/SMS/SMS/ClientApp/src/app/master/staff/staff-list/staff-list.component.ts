import {  Component, OnInit, Output,EventEmitter, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router'
import { FormBuilder, FormControl,FormGroup } from '@angular/forms';
import { StaffrestApiService } from '../staffrest-api.service';
import { Staff } from '../Staff';
import { Subscription} from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { SmsConstant } from 'src/app/shared/constant-values';
import { Console } from 'console';

@Component({
  selector: 'app-staff-list',
  templateUrl: './staff-list.component.html',
  styleUrls: ['./staff-list.component.css']
})
export class StaffListComponent implements OnInit {
  
  department = SmsConstant.department;
  designationList = SmsConstant.designation;
  status = SmsConstant.employmentStatus;
  filters : boolean = false;
  rows : number = 0;
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;
 
  currentUserSubscription !: Subscription;
  currentStaff? : Staff;
  staffs: Staff[] = [];
  staffListData: MatTableDataSource<any>= new MatTableDataSource() ;

  departmentIdFilter = new FormControl('');
  designationFilter = new FormControl('');
  statusvalueFilter = new FormControl('');
  joiningDateFrom = new FormControl('');
  

  columnsToDisplay = ['staffName', 'employeeID','department','designation','status','joiningDate','mobileNumber','eMail','actions'];
  
  filterValues = {
    //department: 
    departmentId :'',
   // designation: '',
    designationId: '',
    //status: '',
    employeementstatusId: '',
    //joiningDateFrom: '',
    joiningDate: ''
    //joiningDateTo: '',
  };

   @BlockUI() blockUI: NgBlockUI;
  stafffilters: FormGroup;
  
  constructor(private fb: FormBuilder,private router:Router, private staffApiService: StaffrestApiService) {
    this.stafffilters = this.fb.group({
      departmentIdFilter: [''],
      designationFilter: [''],
      statusvalueFilter: [''],
      joiningDateFrom: ['']
    });

    this.loadStaff();
    
  }

  // departmentchange(value)
  // {
    
  //   this.staffListData.filter.search(value);
  //     console.log(this.staffListData.filter.search(value));
  // }
  loadStaff()
  {
    this.blockUI.start();

    this.currentUserSubscription = this.staffApiService.getStaffs().subscribe((staff:any) => {
      this.currentStaff = staff;
      this.staffListData.data =staff;
       this.staffListData.paginator = this.paginator;
      this.staffListData.sort = this.sort;
      console.log(this.staffListData);
     
       this.blockUI.stop();
      
      this.rows = this.staffListData.data.length;
    });

  }


  applyFilter(event: any) {
    console.log(event)
  
    const filterValue = this.stafffilters.value[event];
    this.staffListData.filter = filterValue.trim().toLowerCase();
  }
  

  ngOnInit(): void {
    console.log("hai");
   
   
    // this.staffListData = new MatTableDataSource(this.staffs);
    // this.staffListData.paginator = this.paginator;
    // this.staffListData.sort = this.sort;
    
  }

  filterToggle()
  {
    this.filters = !this.filters;
  }

  callNewStudent()
  {  
    this.router.navigate(['new-staff']);
  }
  
  removeStaff(staff : Staff)
  {
    this.staffApiService.deleteStaff(staff.mobile).subscribe(_=>{
      this.loadStaff();
    });
  }

  editStaff(staff : Staff)
  {
    this.router.navigate(['new-staff',staff.mobile]);
    // this.staffApiService.deleteStaff(staff.mobile).subscribe(_=>{
    // });
  }

  createFilter(): (data: any, filter: string) => boolean {
    let filterFunction = function(data, filter): boolean {
      let searchTerms = JSON.parse(filter);
      return data.departmentId.toLowerCase().indexOf(searchTerms.departmentId) !== -1
        && data.designationId.toString().toLowerCase().indexOf(searchTerms.designationId) !== -1
        && data.employeementstatusId.toLowerCase().indexOf(searchTerms.employeementstatusId) !== -1
        && data.joiningDate.toLowerCase().indexOf(searchTerms.joiningDate) !== -1;
    }
    return filterFunction;
  }

}
