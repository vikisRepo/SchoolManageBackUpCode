import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ELetterListComponent } from './e-letter-list.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [ELetterListComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([{path : '',component:ELetterListComponent}
  ]),
SharedModule,
ReactiveFormsModule]})
export class ELetterListModule { }
