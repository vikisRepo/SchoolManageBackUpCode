import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LessonPlanRoutingModule } from './lesson-plan-routing.module';
import { LessonPlanComponent } from './lesson-plan.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { LessonPlanSubjectComponent } from './lesson-plan-subject/lesson-plan-subject.component';
import { ClassesComponent } from './classes/classes.component';
import { AddLesonPlanSubjectwiseComponent } from './add-leson-plan-subjectwise/add-leson-plan-subjectwise.component';
import { AddLessonPlanListviewComponent } from './add-lesson-plan-listview/add-lesson-plan-listview.component';

@NgModule({
  declarations: [LessonPlanComponent, LessonPlanSubjectComponent, ClassesComponent, AddLesonPlanSubjectwiseComponent, AddLessonPlanListviewComponent],
  imports: [
    CommonModule,
    LessonPlanRoutingModule,
    SharedModule,
    ReactiveFormsModule
  ]
  
})
export class LessonPlanModule { }
