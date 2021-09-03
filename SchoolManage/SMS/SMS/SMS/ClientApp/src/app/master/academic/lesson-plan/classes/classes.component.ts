import { Component, OnInit } from '@angular/core';
import { ClassesRestApiService } from './classes-rest-api.service';

@Component({
  selector: 'app-classes-lesson',
  templateUrl: './classes.component.html',
  styleUrls: ['./classes.component.css']
})
export class ClassesComponent implements OnInit {
  // standard:any=
  // [{
  //   className:"1"},{className:"2"},{className:"3"},{className:"4"},{className:"5"},{className:"6"},{className:"7"},{className:"8"},{className:"9"},{className:"10"}];

  standard:any;
  
  constructor(private classesRestApiService : ClassesRestApiService) { 
    
    this.classesRestApiService.getClassGrade().subscribe((data : any) => 
      {
        this.standard  = data;
        console.log(this.standard);
      }
    );
  }
  ngOnInit(): void {


  }
 

}
