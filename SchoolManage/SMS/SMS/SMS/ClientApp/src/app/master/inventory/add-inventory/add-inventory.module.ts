import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddInventoryRoutingModule } from './add-inventory-routing.module';
import { AddInventoryComponent } from './add-inventory.component';
import { InventoryDetailComponent } from './inventory-detail/inventory-detail.component';
import { VendorDetailsComponent } from './vendor-details/vendor-details.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [AddInventoryComponent, InventoryDetailComponent, VendorDetailsComponent],
  imports: [
    CommonModule,
    AddInventoryRoutingModule,
    SharedModule,
    ReactiveFormsModule
  ]
})
export class AddInventoryModule { }
