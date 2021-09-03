import {  Component, OnInit, Output,EventEmitter, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router'
import { FormBuilder, FormControl,FormGroup } from '@angular/forms';
import { StaffrestApiService } from '../../staff/staffrest-api.service';
 import { Staff } from '../inventorydetails';
import { Subscription} from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { SmsConstant } from 'src/app/shared/constant-values';
import { Console } from 'console';

@Component({
  selector: 'app-list-inventory',
  templateUrl: './list-inventory.component.html',
  styleUrls: ['./list-inventory.component.css']
})
export class ListInventoryComponent implements OnInit {

  itemstypes = SmsConstant.itemName;
  itemusageArea = SmsConstant.itemUsageArea;

  filters : boolean = false;
  rows : number = 0;
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;
 
  currentUserSubscription !: Subscription;
  currentStaff? : Staff;
  staffs: Staff[] = [];
  inventoryListData!: MatTableDataSource<any>;

  itemTypeFilter = new FormControl('');
  designationFilter = new FormControl('');
  statusvalueFilter = new FormControl('');
  joiningDateFrom = new FormControl('');
  

  columnsToDisplay = ['itemCode', 'itemName','serialNumber','brand','itemType','itemUsageArea','priperunit','quantity','vendor','attachment','actions'];
  
  // filterValues = {
  //   //department: 
  //   departmentId :'',
  //  // designation: '',
  //   designationId: '',
  //   //status: '',
  //   employeementstatusId: '',
  //   //joiningDateFrom: '',
  //   joiningDate: ''
  //   //joiningDateTo: '',
  // };

   @BlockUI() blockUI: NgBlockUI;
  listinventoryfilters: FormGroup;
  
  constructor(private fb: FormBuilder,private router:Router, private staffApiService: StaffrestApiService) {
    this.listinventoryfilters = this.fb.group({
      itemTypeFilter: [''],
      itemUsageAreaFilter: ['']
    });

    this.loadStaff();
    
  }

  // departmentchange(value)
  // {
    
  //   this.inventoryListData.filter.search(value);
  //     console.log(this.inventoryListData.filter.search(value));
  // }
  loadStaff()
  {
    this.blockUI.start();

    this.currentUserSubscription = this.staffApiService.getStaffs().subscribe((staff:any) => {
      this.currentStaff = staff;
      this.inventoryListData = new MatTableDataSource(staff);
       this.inventoryListData.paginator = this.paginator;
      this.inventoryListData.sort = this.sort;
      console.log(this.inventoryListData);
     // this.inventoryListData.filterPredicate = this.createFilter();
       this.blockUI.stop();
      
      this.rows = this.inventoryListData.data.length;
    });

  }

  

  ngOnInit(): void {
   

  }

  filterToggle()
  {
    this.filters = !this.filters;
  }

  callNewStudent()
  {  
    this.router.navigate(['/add-inventory']);
  }

  applyFilter(event: any) {
    console.log(event,this.listinventoryfilters.value)
  
    const filterValue = this.listinventoryfilters.value[event];
    this.inventoryListData.filter = filterValue.trim().toLowerCase();
  }
  
  removeStaff(staff : Staff)
  {
    this.staffApiService.deleteStaff(staff.mobile).subscribe(_=>{
      this.loadStaff();
    });
  }

  editStaff(staff : Staff)
  {
    this.router.navigate(['/main/add-inventory',staff.mobile]);
    // this.staffApiService.deleteStaff(staff.mobile).subscribe(_=>{
    // });
  }

  // createFilter(): (data: any, filter: string) => boolean {
  //   let filterFunction = function(data, filter): boolean {
  //     let searchTerms = JSON.parse(filter);
  //     return data.departmentId.toLowerCase().indexOf(searchTerms.departmentId) !== -1
  //       && data.designationId.toString().toLowerCase().indexOf(searchTerms.designationId) !== -1
  //       && data.employeementstatusId.toLowerCase().indexOf(searchTerms.employeementstatusId) !== -1
  //       && data.joiningDate.toLowerCase().indexOf(searchTerms.joiningDate) !== -1;
  //   }
  //   return filterFunction;
  // }

}

