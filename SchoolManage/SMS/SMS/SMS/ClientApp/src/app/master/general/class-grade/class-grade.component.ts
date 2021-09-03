import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClassGradeRestApiService } from './class-grade-rest-api.service';

@Component({
  selector: 'app-class-grade',
  templateUrl: './class-grade.component.html',
  styleUrls: ['./class-grade.component.css']
})
export class ClassGradeComponent implements OnInit {

  experiences: any;
  
  // experiences: any = [
  //   {
  //   class: 10,
  //   subject: ['Tamil', 'English', 'Science'],
  //   sections: ['A', 'B', 'C'],
  //   group: '1'
  // },
  // {
  //   class: 2,
  //   subject: ['Tamil', 'English', 'Science'],
  //   sections: ['A', 'B', 'C'],
  //   group: '5',
  // }
// ];

  constructor(private classGradeRestApiService :ClassGradeRestApiService) { }

  ngOnInit(): void {
    this.getData();
  }

  getData(){
      this.classGradeRestApiService.getClassGrades().subscribe(data => {
        this.experiences = data;
      })
  }

  addExperience() {
    this.experiences.push({});
  }

  eventCatch(value:any){
    
    if(value===1){
      this.experiences.pop();
      return;
    }
    this.getData();
    //api 

  }

}
