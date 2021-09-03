import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { NewStaffComponent } from './new-staff.component';

const routes: Routes = [{ path: '', component: NewStaffComponent }] ;

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NewStaffRoutingModule { }
