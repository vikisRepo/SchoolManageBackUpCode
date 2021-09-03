import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { CoursePlanApiService } from '../../course-plan-api.service';

@Component({
  selector: 'app-course-details',
  templateUrl: './course-details.component.html',
  styleUrls: ['./course-details.component.css']
})
export class CourseDetailsComponent implements OnInit {
  @Output() emitcourseformDetails = new EventEmitter();
  courseDetailsForm : FormGroup;

  complitionCriteria =SmsConstant.complitionCriteria;

  constructor(private fb:FormBuilder, private coursePlanApiService : CoursePlanApiService) {

    this.courseDetailsForm= this.fb.group(
      {
        courseName : [''],
        courseCode : [''],
        courseDescription : [''],
        complitionCriteria : [''],
        PassingScore : [''],
        topic : ['']
       
      }
    );
    this.courseDetailsForm.valueChanges.subscribe(()=>{
      this.coursePlanApiService.data  = this.courseDetailsForm.value;   
      this.emitcourseformDetails.emit({ value: this.courseDetailsForm.value,
        valid: this.courseDetailsForm.valid });
        console.log(this.emitcourseformDetails);
    })
  }
  ngOnInit(): void {
  }
  toggle() {

    // if (this.parents.disabled) {
    //   this.parents.enable();
    //   return;
    // }
    // this.parents.reset();
    // this.parents.disable();
  }
}
