import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AcademicDetailRoutingModule } from './academic-detail-routing.module';
import { AcademicDetailComponent } from './academic-detail.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [AcademicDetailComponent],
  imports: [
    CommonModule,
    AcademicDetailRoutingModule,
    SharedModule,
    ReactiveFormsModule
  ]})
export class AcademicDetailModule { }
