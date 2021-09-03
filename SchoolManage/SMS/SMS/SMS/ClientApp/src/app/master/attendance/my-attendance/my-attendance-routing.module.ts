import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MyAttendanceComponent } from './my-attendance.component';

const routes: Routes = [{ path: '', component: MyAttendanceComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MyAttendanceRoutingModule { }
