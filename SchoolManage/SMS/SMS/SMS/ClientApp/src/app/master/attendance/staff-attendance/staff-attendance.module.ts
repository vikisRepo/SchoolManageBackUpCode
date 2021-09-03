import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StaffAttendanceRoutingModule } from './staff-attendance-routing.module';
import { StaffAttendanceComponent } from './staff-attendance.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AngularMaterialModule } from 'src/angular-material.module';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [StaffAttendanceComponent],
  imports: [
    CommonModule,
    StaffAttendanceRoutingModule,
    AngularMaterialModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class StaffAttendanceModule { }
