import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StaffFeedbackListComponent } from './staff-feedback-list.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [StaffFeedbackListComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([{path : '',component:StaffFeedbackListComponent}
  ]),
SharedModule,
ReactiveFormsModule]})
export class StaffFeedbackListModule { }
