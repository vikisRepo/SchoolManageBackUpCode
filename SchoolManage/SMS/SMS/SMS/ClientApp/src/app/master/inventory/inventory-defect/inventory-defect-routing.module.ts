import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { InventoryDefectComponent } from './inventory-defect.component';

const routes: Routes = [{ path: '', component: InventoryDefectComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InventoryDefectRoutingModule { }
