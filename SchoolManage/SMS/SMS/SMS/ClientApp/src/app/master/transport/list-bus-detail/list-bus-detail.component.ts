import { Component, OnInit, Output,EventEmitter, ViewChild, AfterViewInit } from '@angular/core';
import { Subscription} from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { BusanddriverService } from '../add-bus-details/busanddriver.service';
import { BusAndDriver } from '../add-bus-details/BusAndDriver';

@Component({
  selector: 'app-list-bus-detail',
  templateUrl: './list-bus-detail.component.html',
  styleUrls: ['./list-bus-detail.component.css']
})
export class ListBusDetailComponent implements OnInit {
  @BlockUI() blockUI: NgBlockUI;
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;
  rows : number = 0;

  currentUserSubscription !: Subscription;
  currentBusAndDriver? : BusAndDriver;
  busanddriver: BusAndDriver[] = [];


  ListbusData: MatTableDataSource<any>= new MatTableDataSource() ;
  // ListbusData: MatTableDataSource<any>= new MatTableDataSource() ;
  //  ListbusData=[{
  //   "busNumber":"one",
  //   'companyName':'one',
  //    'driverName':'one',
  //    'driverNumber':'one'
  // }];
  
  columnsToDisplay = ['busNumber', 'companyName','driverName','driverNumber'];
  constructor(private router:Router,private busanddriverApiService: BusanddriverService) { 
    //debugger;
    this.loadBusDetails();
  }

  loadBusDetails()
  {
    this.blockUI.start();

    this.currentUserSubscription = this.busanddriverApiService.getBusAnddrivers().subscribe((busanddriver:any) => {
      this.currentBusAndDriver = busanddriver;
      this.ListbusData.data =busanddriver;
       this.ListbusData.paginator = this.paginator;
      this.ListbusData.sort = this.sort;
      console.log(this.ListbusData);
     
       this.blockUI.stop();
     // debugger;
      this.rows = this.ListbusData.data.length;
    });

  }
  

  ngOnInit(): void {
      
  }


  callNewStudent()
  {  
    this.router.navigate(['new-staff']);
  }
  
  removeBusDetail(busanddriver : BusAndDriver)//Staff
  {
    this.busanddriverApiService.deleteBusAnddriver(busanddriver.busTypeid).subscribe(_=>{
      this.loadBusDetails();
    });
  }

  editBusdetail(busanddriver : BusAndDriver)
  {
    this.router.navigate(['new-staff',busanddriver.busTypeid]);
  }
}






  


