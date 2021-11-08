import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { BusanddriverService } from '../add-bus-details/busanddriver.service';
import { BusTrips } from '../list-bus-trips/BusTrips';
import { TransportService } from '../transport.service';
import { Subscription } from 'rxjs';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-list-bus-trips',
  templateUrl: './list-bus-trips.component.html',
  styleUrls: ['./list-bus-trips.component.css']
})
export class ListBusTripsComponent implements OnInit {
  @BlockUI() blockUI: NgBlockUI;
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;
  rows : number = 0;
  currentUserSubscription !: Subscription;
  currentBusTrips? : BusTrips;
  bustrips: BusTrips[] = [];
  ListbusTrips: MatTableDataSource<any>= new MatTableDataSource();
  columnsToDisplay = ['TripNumber', 'busNumber','driverName','driverNumber','totalNoOfStudent', 'actions'];
  
  constructor(private router :Router, private transportService : TransportService, public dialog: MatDialog) {

  }

  ngOnInit(): void {
    this.loadBusTrips();
  }

  loadBusTrips(){
    this.currentUserSubscription = this.transportService.getBusTripDetails().subscribe((busTrips:any) => {
      this.ListbusTrips.data =busTrips;
      this.ListbusTrips.paginator = this.paginator;
      this.ListbusTrips.sort = this.sort;
      console.log(this.ListbusTrips);
      this.blockUI.stop();
      this.rows = this.ListbusTrips.data.length;
    });
  }

  callNewBusTrips(){
    this.router.navigate(['add-bus-trip']);
  }

  editBustrips(bustrips :any)
  {
    this.router.navigate(['add-bus-trip',bustrips.busTripid]);
  }

  removeBusTrips(bustrips :any)
  {
    this.transportService.deleteBusTripDetail(bustrips.busTripid).subscribe(_=>{
      this.dialog.open(MessageBoxComponent, { width: '350px', height: '100px', data: "Trip Details Deleted successfully !" });
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500);
      this.loadBusTrips();
    });
  }
}
