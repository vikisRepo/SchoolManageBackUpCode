import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { StaffListComponent } from './staff-list.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [StaffListComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: StaffListComponent }
    ]),
    SharedModule,
    ReactiveFormsModule
  ]
})
export class StaffListModule { }
