import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ListBusTripsComponent } from './list-bus-trips.component';

const routes: Routes = [{ path: '', component: ListBusTripsComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ListBusTripsRoutingModule { }
