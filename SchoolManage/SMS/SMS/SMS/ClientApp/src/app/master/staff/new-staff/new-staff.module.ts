import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NewStaffRoutingModule } from './new-staff-routing.module';
import { NewStaffComponent } from './new-staff.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { PersonalDetailsComponent } from './personal-details/personal-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { EmployeeExperienceComponent } from './employee-experience/employee-experience.component';
import { BankingDetailsComponent } from './banking-details/banking-details.component';
import { MasterModule } from '../../master.module';



@NgModule({
  declarations: [NewStaffComponent,PersonalDetailsComponent, EmployeeDetailsComponent, 
    EmployeeExperienceComponent, BankingDetailsComponent
  ],
  imports: [
    CommonModule,
    NewStaffRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    MasterModule
  ]
})
export class NewStaffModule { }
