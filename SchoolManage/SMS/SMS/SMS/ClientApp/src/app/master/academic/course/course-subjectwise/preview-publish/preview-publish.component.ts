import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CoursePlanApiService } from '../../course-plan-api.service';

@Component({
  selector: 'app-preview-publish',
  templateUrl: './preview-publish.component.html',
  styleUrls: ['./preview-publish.component.css']
})
export class PreviewPublishComponent implements OnInit {
  @Output() emitcourseformDetails = new EventEmitter();
  @Input() getFormValues = {};
cDate:any;
  prePublishForm:FormGroup;
  constructor(private fb:FormBuilder, private coursePlanApiService : CoursePlanApiService) {
    this.prePublishForm = this.fb.group({
        courseName : [''],
        courseCode : [''],
        courseDescription : [''],
        complitionCriteria : [''],
        topic : ['']


    });
    this.prePublishForm.valueChanges.subscribe(()=>{
      // this.emitcourseformDetails.emit({value:this.prePublishForm.value,valid:this.prePublishForm.valid})
    })
   }

  ngOnInit(): void {
     this.prePublishForm.patchValue(this.coursePlanApiService.data);
  }

}
