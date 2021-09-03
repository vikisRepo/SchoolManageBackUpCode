import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ClassTimetableComponent } from './class-timetable.component';

const routes: Routes = [{ path: '', component: ClassTimetableComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClassTimetableRoutingModule { }
