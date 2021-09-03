import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { StudentListComponent } from '../../student/student-list/student-list.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [StudentListComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: StudentListComponent }
    ]),
    SharedModule,
    ReactiveFormsModule
  ]
})
export class StudentListModule { }
