import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ApplyLeaveRoutingModule } from './apply-leave-routing.module';
import { ApplyLeaveComponent } from './apply-leave.component';
import { AngularMaterialModule } from 'src/angular-material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [ApplyLeaveComponent],
  imports: [
    CommonModule,
    ApplyLeaveRoutingModule,
    AngularMaterialModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class ApplyLeaveModule {
 }
