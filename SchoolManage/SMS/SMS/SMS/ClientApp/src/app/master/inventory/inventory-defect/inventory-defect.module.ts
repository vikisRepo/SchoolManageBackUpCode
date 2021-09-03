import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InventoryDefectRoutingModule } from './inventory-defect-routing.module';
import { InventoryDefectComponent } from './inventory-defect.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { MasterModule } from '../../master.module';


@NgModule({
  declarations: [InventoryDefectComponent],
  imports: [
    CommonModule,
    InventoryDefectRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    MasterModule
  ]
})
export class InventoryDefectModule { }
