import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { BusanddriverService } from '../add-bus-details/busanddriver.service';
import { BusTrips } from '../list-bus-trips/BusTrips';

@Component({
  selector: 'app-list-bus-trips',
  templateUrl: './list-bus-trips.component.html',
  styleUrls: ['./list-bus-trips.component.css']
})
export class ListBusTripsComponent implements OnInit {

  rows : number=0;
  
  currentBusTrips? : BusTrips;
  bustrips: BusTrips[] = [];
  // ListbusTrips: MatTableDataSource<any>= new MatTableDataSource() ;
  ListbusTrips=[{
    "TripNumber":"one",
    'busNumber':'one',
     'driverName':'one',
     'driverNumber':'one',
     'totalNoOfStudent':5
  }];
  columnsToDisplay = ['TripNumber', 'busNumber','driverName','driverNumber','totalNoOfStudent'];
  constructor(private router :Router) {
      this.loadBusTrips();
   }

  ngOnInit(): void {
  }

  loadBusTrips(){
    // this.blockUI.start();

    // this.currentUserSubscription = this.busanddriverApiService.getBusAnddrivers().subscribe((busanddriver:any) => {
    //   this.currentBusAndDriver = busanddriver;
    //   this.ListbusData.data =busanddriver;
    //    this.ListbusData.paginator = this.paginator;
    //   this.ListbusData.sort = this.sort;
    //   console.log(this.ListbusData);
     
    //    this.blockUI.stop();
    //   debugger;
    //   this.rows = this.ListbusData.data.length;
    // });
  }
  callNewBusTrips(){
    this.router.navigate(['add-bus-trip']);
  }

  editBustrips(bustrips :BusTrips)
  {
    this.router.navigate(['new-staff',bustrips.busNumber]);
  }

  removeBusTrips(bustrips :BusTrips)
  {
    // this.busanddriverApiService.deleteBusAnddriver(bustrips.busNumber).subscribe(_=>{
    //   this.loadBusDetails();
    // });
  }
}
