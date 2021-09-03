import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClassGradeRoutingModule } from './class-grade-routing.module';
import { ClassGradeComponent } from './class-grade.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { ClassSectionComponent } from './class-section/class-section.component';


@NgModule({
  declarations: [ClassGradeComponent, ClassSectionComponent],
  imports: [
    CommonModule,
    ClassGradeRoutingModule,
    RouterModule.forChild([{path : '',component:ClassGradeComponent}
  ]),
  SharedModule,
  ReactiveFormsModule
]})
export class ClassGradeModule { }
