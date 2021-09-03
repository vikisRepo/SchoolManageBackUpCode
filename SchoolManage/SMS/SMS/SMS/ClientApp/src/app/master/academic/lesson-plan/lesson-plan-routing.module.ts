import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddLesonPlanSubjectwiseComponent } from './add-leson-plan-subjectwise/add-leson-plan-subjectwise.component';
import { AddLessonPlanListviewComponent } from './add-lesson-plan-listview/add-lesson-plan-listview.component';
import { ClassesComponent } from './classes/classes.component';
import { LessonPlanSubjectComponent } from './lesson-plan-subject/lesson-plan-subject.component';

import { LessonPlanComponent } from './lesson-plan.component';

const routes: Routes = [{
  path: '', component: LessonPlanComponent, children: [
     { path: '', component: ClassesComponent },
    { path: 'subjectDetails/:class', component: LessonPlanSubjectComponent },
    { path: 'addsLessonPlanSubjectWise/:subject/:class',component:AddLesonPlanSubjectwiseComponent},
    { path: 'addsLessonPlanSubjectWise/:id',component:AddLesonPlanSubjectwiseComponent},
    { path: 'addLessonPlanListview/:subject/:class',component:AddLessonPlanListviewComponent}
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LessonPlanRoutingModule { }
