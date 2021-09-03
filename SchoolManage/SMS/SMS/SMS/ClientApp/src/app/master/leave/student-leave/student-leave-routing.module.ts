import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { StudentLeaveComponent } from './student-leave.component';

const routes: Routes = [{ path: '', component: StudentLeaveComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudentLeaveRoutingModule { }
