import { Component, OnInit, Output, EventEmitter, Input, OnChanges, SimpleChanges } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FormControl, FormGroup, FormArray } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { SmsConstant } from 'src/app/shared/constant-values';
import {AlertService } from 'src/app/shared/alert';
import { LessonPlanRestApiService } from '../lesson-plan-rest-api.service';
import { validateBasis } from '@angular/flex-layout';
@Component({
  selector: 'app-add-leson-plan-subjectwise',
  templateUrl: './add-leson-plan-subjectwise.component.html',
  styleUrls: ['./add-leson-plan-subjectwise.component.css']
})
export class AddLesonPlanSubjectwiseComponent implements OnInit {
  subjectwiselessonform:FormGroup;
   subject:any;
   class:any;
   id?: any;
   isAddMode?: boolean;

   options = {
    autoClose: false,
    keepAfterRouteChange: false
     };

  constructor(private fb:FormBuilder,private route: ActivatedRoute,
    private router: Router,protected alertService: AlertService, private lessonPlanRestApiService : LessonPlanRestApiService) { 
      
    this.subjectwiselessonform=this.fb.group({
      date: ['',Validators.required],
      classWork: ['',Validators.required],
      homeWork: ['',Validators.required],
      lesson: ['',Validators.required],
      games: ['',Validators.required],
      activity: ['',Validators.required],
      classActivity:['',Validators.required],
      topic:['',Validators.required],
      extraInfo:['',Validators.required],
      concept:['',Validators.required]
    });
   }
onSubmit() {

  this.subjectwiselessonform.markAllAsTouched();
  let classSubject= {className:this.class,subjectName:this.subject};
  Object.assign(classSubject,this.subjectwiselessonform.value);

    // TODO: Use EventEmitter with form value
    // console.warn(this.subjectwiselessonform.value);
    this.lessonPlanRestApiService.createLessonPlan(classSubject).subscribe(_ => {});
  }
  ngOnInit(): void {

    this.subject = this.route.snapshot.paramMap.get('subject');
    this.class = this.route.snapshot.paramMap.get('class');

    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;

    if (!this.isAddMode)
    {
      this.loadLessonPlan();
    }
    
  }

  navToListView(){
    this.router.navigate(["lesson-plan/addLessonPlanListview/"+ this.subject+"/"+this.class]);
  }

  loadLessonPlan()
  {
    this.lessonPlanRestApiService.getLessonPlan(this.id).subscribe(data => {
      this.subjectwiselessonform.patchValue(data);
      this.subject = data.subjectDescr;
    });
  }

}
