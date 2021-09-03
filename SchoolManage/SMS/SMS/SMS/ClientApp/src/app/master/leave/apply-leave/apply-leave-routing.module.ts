import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ApplyLeaveComponent } from './apply-leave.component';

const routes: Routes = [{ path: '', component: ApplyLeaveComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ApplyLeaveRoutingModule { }
