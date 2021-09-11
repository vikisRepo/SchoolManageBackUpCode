import { Component, OnInit, ViewChildren } from '@angular/core';
import {FormControl} from '@angular/forms';
import { StudentrestApiService } from './../studentrest-api.service'
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { Student } from '../student';
import { ActivatedRoute } from '@angular/router';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { MatDialog } from '@angular/material/dialog';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';
import { QueryList } from '@angular/core';

@Component({
  selector: 'app-new-student',
  templateUrl: './new-student.component.html',
  styleUrls: ['./new-student.component.css']
  
})
export class NewStudentComponent implements OnInit {

  stuFormtDetails: boolean[] =[]
  results : any =null;
  stuJsonResult: any ={};
  selectedTab:number=0;
  isAddMode?: boolean;
  _student : Student;
  id : any;

  @ViewChildren("dt") dt: QueryList<FormTouched>;
  @BlockUI() blockUI: NgBlockUI;
  
  constructor(private studentApiService: StudentrestApiService, private route: ActivatedRoute, public dialog: MatDialog) { }

  ngAfterViewInit(): void {

    if(!this.isAddMode)
    {
      debugger;
      this.studentApiService.getStudent(this.id)
        .subscribe(studentdetails => {
          this._student = studentdetails;
          debugger;
          this.studentApiService.setFormValue(studentdetails);
          console.log(this._student);
        }, error => console.log(error));
    }
    
  }
  

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;
  }

  btnMovement(st: string) {
  //  let flg = this.dt.toArray()[this.selectedTab].formTouched();
   // console.log(flg)
   
      if (st === 'bck') {
        this.selectedTab--;
      }
      else if (st === 'frd') {
        if (this.selectedTab >= 3) {
          this.submit();
          return;
        }
        this.selectedTab++;
      }
    
  }

  submit(){

    this.blockUI.start();
    // this.submitted = true;


   if (this.stuFormtDetails.includes(false)) {
       this.blockUI.stop();
      return;
    }

    if (this.isAddMode) {
      this.createStudent();
     } else {
      this.updateStudent();
     }

     this.blockUI.stop();

    // if(!this.stuFormtDetails.includes(false)){
    //   return;
    // }
    
  }

  createStudent()
  {
    console.log(JSON.stringify(this.stuJsonResult));
    this.studentApiService.createStudent(this.stuJsonResult).subscribe(_=>{
      this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"student feedback updated successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500);
    });
  }

  updateStudent()
  {
    this.studentApiService.updateStudent(this.id, this.stuJsonResult).subscribe(_=>{

    });
  }
  
  setTabFormDetails(value: any,tab:number){
    this.stuFormtDetails[tab] = value.valid;
    Object.assign(this.stuJsonResult,value.value);
    console.log(value.value);
  }


}

