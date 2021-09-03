import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LeaveConfigurationComponent } from './leave-configuration.component';

const routes: Routes = [{ path: '', component: LeaveConfigurationComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LeaveConfigurationRoutingModule { }
