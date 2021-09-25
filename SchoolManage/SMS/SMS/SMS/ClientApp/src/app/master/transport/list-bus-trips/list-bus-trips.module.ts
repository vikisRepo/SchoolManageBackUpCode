import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ListBusTripsRoutingModule } from './list-bus-trips-routing.module';
import { ListBusTripsComponent } from './list-bus-trips.component';
import { MatTableModule } from '@angular/material/table';


@NgModule({
  declarations: [ListBusTripsComponent],
  imports: [
    CommonModule,
    ListBusTripsRoutingModule,
    MatTableModule 
  ]
})
export class ListBusTripsModule { }
