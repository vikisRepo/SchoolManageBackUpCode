import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-course-subjectwise',
  templateUrl: './course-subjectwise.component.html',
  styleUrls: ['./course-subjectwise.component.css']
})
export class CourseSubjectwiseComponent implements OnInit {

  emitcourseformDetails: boolean[] =[]
  results : any =null;
  courseJsonResult: any ={};
  selectedTab:number=0;
  isAddMode?: boolean;
  submitted = false;

  subject:any;
  class:any;
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.subject = this.route.snapshot.paramMap.get('subject');
    this.class = this.route.snapshot.paramMap.get('class');
  }
  btnMovement(st:string){

    if(st==='bck'){
      this.selectedTab--;
    }
    else if (st === 'frd') {

      if (this.selectedTab >= 4) {
        this.submit();
        return;
      }
      this.selectedTab++;
    }

  }
  submit(){
    this.submitted = true;
    if(!this.emitcourseformDetails.includes(false)){
      return;
    }
    if (this.isAddMode) {
      this.createStaff();
     } else {
      this.updateSatff();
     }
    // this.studentApiService.createStudent(this.stuJsonResult).subscribe(_=>{
    // });

    console.log('submited');
  }
    
  createStaff()
  {
    // this.staffApiService.createStaff(this.conResults).subscribe(_=>{
    // });
  }
  updateSatff()
  {
    // this.staffApiService.updateStaff(this.id, this.conResults).subscribe(_=>{

    // });
  }

  setTabFormDetails(value: any,tab:number){
    this.emitcourseformDetails[tab] = value.valid;
    Object.assign(this.courseJsonResult,value.value);
    console.log(this.courseJsonResult);
  }
}

