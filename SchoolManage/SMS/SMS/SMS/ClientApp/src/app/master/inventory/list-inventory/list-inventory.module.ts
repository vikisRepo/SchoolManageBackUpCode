import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatPaginator } from '@angular/material/paginator';
import { ListInventoryRoutingModule } from './list-inventory-routing.module';
import { ListInventoryComponent } from './list-inventory.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [ListInventoryComponent],
  imports: [
    CommonModule,
    ListInventoryRoutingModule,
    SharedModule,
    ReactiveFormsModule
  ]
})
export class ListInventoryModule { }
