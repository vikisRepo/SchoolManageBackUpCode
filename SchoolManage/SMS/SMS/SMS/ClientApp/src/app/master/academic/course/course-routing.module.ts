import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CourseClassesComponent } from './course-classes/course-classes.component';
import { CourseListViewComponent } from './course-list-view/course-list-view.component';
import { CourseSubjectComponent } from './course-subject/course-subject.component';
import { CourseSubjectwiseComponent } from './course-subjectwise/course-subjectwise.component';

import { CourseComponent } from './course.component';

const routes: Routes = [{
  path: '', component: CourseComponent, children: [
    { path: '', component: CourseClassesComponent },
    { path: 'courseSubjectDetails/:class', component: CourseSubjectComponent },
    { path: 'courseListView/:subject/:class',component:CourseListViewComponent},
    { path: 'courseSubjectwise/:subject/:class', component: CourseSubjectwiseComponent }
  ]
}];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CourseRoutingModule { }
