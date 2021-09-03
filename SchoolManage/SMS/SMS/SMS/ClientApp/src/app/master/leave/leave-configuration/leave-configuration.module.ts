import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LeaveConfigurationRoutingModule } from './leave-configuration-routing.module';
import { LeaveConfigurationComponent } from './leave-configuration.component';
import { AngularMaterialModule } from 'src/angular-material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [LeaveConfigurationComponent],
  imports: [
    CommonModule,
    LeaveConfigurationRoutingModule,
    AngularMaterialModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class LeaveConfigurationModule { }
