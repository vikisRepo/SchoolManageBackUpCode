import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentFeedbackComponent } from './student-feedback.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [StudentFeedbackComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([{path:'',component:StudentFeedbackComponent}]),
    SharedModule,
    ReactiveFormsModule
  ]
})
export class StudentFeedbackModule { }
