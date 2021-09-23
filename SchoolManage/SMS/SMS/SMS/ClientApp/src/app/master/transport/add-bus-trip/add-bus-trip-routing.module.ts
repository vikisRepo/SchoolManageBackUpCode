import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddBusTripComponent } from './add-bus-trip.component';

const routes: Routes = [{ path: '', component: AddBusTripComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AddBusTripRoutingModule { }
