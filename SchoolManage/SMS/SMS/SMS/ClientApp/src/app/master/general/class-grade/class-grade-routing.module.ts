import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ClassGradeComponent } from './class-grade.component';

const routes: Routes = [{ path: '', component: ClassGradeComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClassGradeRoutingModule { }
