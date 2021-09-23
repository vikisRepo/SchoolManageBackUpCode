import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ListBusDetailRoutingModule } from './list-bus-detail-routing.module';
import { ListBusDetailComponent } from './list-bus-detail.component';
import { MatTableModule } from '@angular/material/table'  


@NgModule({
  declarations: [ListBusDetailComponent],
  imports: [
    CommonModule,
    ListBusDetailRoutingModule,
    MatTableModule
  ]
})
export class ListBusDetailModule { }
