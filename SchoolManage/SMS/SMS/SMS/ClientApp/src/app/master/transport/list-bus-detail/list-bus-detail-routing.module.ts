import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ListBusDetailComponent } from './list-bus-detail.component';

const routes: Routes = [{ path: '', component: ListBusDetailComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ListBusDetailRoutingModule { }
