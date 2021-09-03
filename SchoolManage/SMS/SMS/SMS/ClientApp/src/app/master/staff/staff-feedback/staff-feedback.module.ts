import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StaffFeedbackComponent } from './staff-feedback.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [StaffFeedbackComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([{path:'',component:StaffFeedbackComponent}]),
    SharedModule,
    ReactiveFormsModule
  ]
})
export class StaffFeedbackModule { }
