import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MyAttendanceRoutingModule } from './my-attendance-routing.module';
import { MyAttendanceComponent } from './my-attendance.component';
import { AngularMaterialModule } from 'src/angular-material.module';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [MyAttendanceComponent],
  imports: [
    CommonModule,
    MyAttendanceRoutingModule,
    AngularMaterialModule,
    SharedModule
  ]
})
export class MyAttendanceModule { }
