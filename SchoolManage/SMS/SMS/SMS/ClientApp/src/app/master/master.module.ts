import { NgModule,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MasterRoutingModule } from './master-routing.module';
import { MasterComponent } from './master.component';
import { HeaderComponent } from './components/header/header.component';
import { SideMenuComponent } from './components/side-menu/side-menu.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { AngularMaterialModule } from 'src/angular-material.module';
import { AngularFileUploaderModule } from "angular-file-uploader";

import { AvatarModule } from 'ngx-avatar';
import {MatIconModule} from '@angular/material/icon';
import { TripDetailsComponent } from './transport/trip-details/trip-details.component';








@NgModule({
  declarations: [
    MasterComponent,
    HeaderComponent,
    SideMenuComponent,
    TripDetailsComponent
  ],
  imports: [
    CommonModule,
    MasterRoutingModule,
    HttpClientModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    AngularMaterialModule,
    AngularFileUploaderModule,
    AvatarModule,
    MatIconModule
  ]
})
export class MasterModule { }
