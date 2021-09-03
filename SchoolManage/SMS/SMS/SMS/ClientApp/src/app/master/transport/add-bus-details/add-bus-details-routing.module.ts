import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddBusDetailsComponent } from './add-bus-details.component';

const routes: Routes = [{ path: '', component: AddBusDetailsComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AddBusDetailsRoutingModule { }
