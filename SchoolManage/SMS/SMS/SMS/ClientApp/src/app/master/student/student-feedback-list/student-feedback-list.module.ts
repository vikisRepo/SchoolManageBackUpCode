import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentFeedbackListComponent } from './student-feedback-list.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [StudentFeedbackListComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: StudentFeedbackListComponent }
    ]),
    SharedModule,
    ReactiveFormsModule
  ]
})
export class StudentFeedbackListModule {
  
 }
