import { Component, OnInit } from '@angular/core';
import { ClassesRestApiService } from '../../lesson-plan/classes/classes-rest-api.service';

@Component({
  selector: 'app-course-classes',
  templateUrl: './course-classes.component.html',
  styleUrls: ['./course-classes.component.css']
})
export class CourseClassesComponent implements OnInit {
  standard:any;
  // [{
  //   class:"1"},{class:"2"},{class:"3"},{class:"4"},{class:"5"},{class:"6"},{class:"7"},{class:"8"},{class:"9"},{class:"10"}];

     constructor(private classesRestApiService : ClassesRestApiService) { }

  ngOnInit(): void {
    this.classesRestApiService.getClassGrade().subscribe((data : any) => 
    {
      this.standard  = data;
      console.log(this.standard);
    }
  );
  }

}
