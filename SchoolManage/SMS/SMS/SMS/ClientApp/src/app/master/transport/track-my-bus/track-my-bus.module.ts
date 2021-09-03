import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TrackMyBusRoutingModule } from './track-my-bus-routing.module';
import { TrackMyBusComponent } from './track-my-bus.component';


@NgModule({
  declarations: [TrackMyBusComponent],
  imports: [
    CommonModule,
    TrackMyBusRoutingModule
  ]
})
export class TrackMyBusModule { }
