import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AcademicDetailComponent } from './academic-detail.component';

const routes: Routes = [{ path: '', component: AcademicDetailComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AcademicDetailRoutingModule { }
