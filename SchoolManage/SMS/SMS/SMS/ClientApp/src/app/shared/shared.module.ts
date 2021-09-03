import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AngularMaterialModule } from 'src/angular-material.module';
import { HeaderActionComponent } from './header-action/header-action.component';
import { AddressDetailComponent } from './address/address-detail/address-detail.component';
import { AddressDetailsComponent } from './address/address-details/address-details.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ClassesComponent } from './classes/classes.component';
import { MessageBoxComponent } from './dialog-boxes/message-box/message-box.component';






@NgModule({
  declarations: [HeaderActionComponent,AddressDetailComponent,
    AddressDetailsComponent,
    ClassesComponent,
    MessageBoxComponent
    ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AngularMaterialModule
  ],
  exports:[AngularMaterialModule,HeaderActionComponent,AddressDetailComponent,
    AddressDetailsComponent,ClassesComponent,MessageBoxComponent]
})
export class SharedModule { }
