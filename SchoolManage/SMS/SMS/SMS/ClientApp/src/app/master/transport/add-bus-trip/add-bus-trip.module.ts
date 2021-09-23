import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddBusTripRoutingModule } from './add-bus-trip-routing.module';
import { AddBusTripComponent } from './add-bus-trip.component';


@NgModule({
  declarations: [AddBusTripComponent],
  imports: [
    CommonModule,
    AddBusTripRoutingModule
  ]
})
export class AddBusTripModule { }
