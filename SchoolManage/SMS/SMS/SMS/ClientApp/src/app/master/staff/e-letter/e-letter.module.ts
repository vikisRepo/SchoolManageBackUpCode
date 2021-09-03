import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ELetterComponent } from './e-letter.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';




@NgModule({ 
  declarations: [ELetterComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([{path : '',component:ELetterComponent}
  ]),
    SharedModule,
    ReactiveFormsModule
]})
export class ELetterModule { }
