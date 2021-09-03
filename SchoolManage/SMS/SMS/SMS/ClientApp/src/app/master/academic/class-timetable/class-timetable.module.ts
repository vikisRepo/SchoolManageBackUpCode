import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClassTimetableRoutingModule } from './class-timetable-routing.module';
import { ClassTimetableComponent } from './class-timetable.component';
import { TimeTableEditorComponent } from './time-table-editor/time-table-editor.component';
import { TimeTableViewerComponent } from './time-table-viewer/time-table-viewer.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { TimeTableService } from './services/time-table.service';


@NgModule({
  declarations: [ClassTimetableComponent, TimeTableEditorComponent, TimeTableViewerComponent],
  imports: [
    CommonModule,
    ClassTimetableRoutingModule,
    SharedModule,
    ReactiveFormsModule
  ],
  providers:[TimeTableService]
})
export class ClassTimetableModule { }
