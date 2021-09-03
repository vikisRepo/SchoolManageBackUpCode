import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CourseRoutingModule } from './course-routing.module';
import { CourseComponent } from './course.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CourseClassesComponent } from './course-classes/course-classes.component';
import { ReactiveFormsModule } from '@angular/forms';
import { StudentListModule } from '../../student/student-list/student-list.module';

import { CourseSubjectwiseComponent } from './course-subjectwise/course-subjectwise.component';
import { CourseSubjectComponent } from './course-subject/course-subject.component';
import { CourseDetailsComponent } from './course-subjectwise/course-details/course-details.component';
import { ContentUploadComponent } from './course-subjectwise/content-upload/content-upload.component';
import { TargetStudentComponent } from './course-subjectwise/target-student/target-student.component';
import { PreviewPublishComponent } from './course-subjectwise/preview-publish/preview-publish.component';
import { CourseListViewComponent } from './course-list-view/course-list-view.component';



@NgModule({
  declarations: [CourseComponent, CourseClassesComponent,  CourseSubjectwiseComponent, CourseSubjectComponent, CourseDetailsComponent, ContentUploadComponent, TargetStudentComponent, 
    PreviewPublishComponent, CourseListViewComponent],
  imports: [
    CommonModule,
    CourseRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    StudentListModule
  ]
})
export class CourseModule { }
