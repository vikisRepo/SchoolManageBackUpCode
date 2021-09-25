import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddBusTripRoutingModule } from './add-bus-trip-routing.module';
import { AddBusTripComponent } from './add-bus-trip.component';
import { TripDetailsComponent } from './trip-details/trip-details.component';
import { StudentDetailsComponent } from './student-details/student-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { MasterModule } from '../../master.module';
import { NgxDocViewerModule } from 'ngx-doc-viewer';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';


@NgModule({
  declarations: [AddBusTripComponent, TripDetailsComponent, StudentDetailsComponent],
  imports: [
    CommonModule,
    AddBusTripRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    MasterModule,
    NgxDocViewerModule,
    NgxMaterialTimepickerModule
  ]
})
export class AddBusTripModule { }
