import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddBusDetailsRoutingModule } from './add-bus-details-routing.module';
import { AddBusDetailsComponent } from './add-bus-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AngularFileUploaderModule } from 'angular-file-uploader';
import { NgxDocViewerModule } from 'ngx-doc-viewer';
import { SharedModule } from 'src/app/shared/shared.module';
import { MasterModule } from '../../master.module';
import { AddBusComponent } from './add-bus/add-bus.component';
import { DriverDetailsComponent } from './driver-details/driver-details.component';


@NgModule({
  declarations: [AddBusDetailsComponent, AddBusComponent, DriverDetailsComponent,],
  imports: [
    CommonModule,
    AddBusDetailsRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    MasterModule,
    AngularFileUploaderModule, 
    NgxDocViewerModule
  ]
})
export class AddBusDetailsModule { }
