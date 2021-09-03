import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddInventoryComponent } from './add-inventory.component';

const routes: Routes = [{ path: '', component: AddInventoryComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AddInventoryRoutingModule { }
