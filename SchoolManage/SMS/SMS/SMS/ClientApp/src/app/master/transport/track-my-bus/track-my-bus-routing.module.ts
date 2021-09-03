import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TrackMyBusComponent } from './track-my-bus.component';

const routes: Routes = [{ path: '', component: TrackMyBusComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TrackMyBusRoutingModule { }
