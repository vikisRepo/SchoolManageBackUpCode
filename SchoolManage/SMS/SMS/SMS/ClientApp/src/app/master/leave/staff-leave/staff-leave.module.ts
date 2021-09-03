import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StaffLeaveRoutingModule } from './staff-leave-routing.module';
import { StaffLeaveComponent } from './staff-leave.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AngularMaterialModule } from 'src/angular-material.module';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [StaffLeaveComponent],
  imports: [
    CommonModule,
    StaffLeaveRoutingModule,
    AngularMaterialModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class StaffLeaveModule { }
