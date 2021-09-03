import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SubjectRoutingModule } from './subject-routing.module';
import { SubjectComponent } from './subject.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { SubjectsComponent } from './subjects/subjects.component';
import { RouterModule } from '@angular/router';
import { SimpleNotificationsModule} from 'angular2-notifications';
// import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [SubjectComponent, SubjectsComponent],
  imports: [
    CommonModule,
    SubjectRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    RouterModule.forChild([{path : '',component:SubjectComponent}]),
    SimpleNotificationsModule.forRoot(),
    // BrowserAnimationsModule
  ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class SubjectModule { }
