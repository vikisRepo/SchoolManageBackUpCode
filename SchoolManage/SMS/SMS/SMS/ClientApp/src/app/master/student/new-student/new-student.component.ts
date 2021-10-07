import { Component, EventEmitter, OnInit, Output, ViewChildren } from '@angular/core';
import {FormControl} from '@angular/forms';
import { StudentrestApiService } from './../studentrest-api.service'
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { Student } from '../student';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { MatDialog } from '@angular/material/dialog';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';
import { QueryList } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-new-student',
  templateUrl: './new-student.component.html',
  styleUrls: ['./new-student.component.css']
  
})
export class NewStudentComponent implements OnInit {

  stuFormtDetails: boolean[] =[]
  // @Output() dependentsdetails = new EventEmitter();
  results : any =null;
  stuJsonResult: any ={};
  selectedTab:number=0;
  isAddMode?: boolean;
  _student : Student;
  id : any;
  submitted = false;
  public parentAdmissionNumber : any;

  @ViewChildren("dt") dt: QueryList<FormTouched>;
  @BlockUI() blockUI: NgBlockUI;

  parentG=null;
  documentDetails = {};
  
  constructor(private studentApiService: StudentrestApiService, private route: ActivatedRoute, public dialog: MatDialog,
    private router: Router) { }

  ngAfterViewInit(): void {

    if(!this.isAddMode)
    {
      this.parentAdmissionNumber = this.id;
      debugger;
      this.documentDetails = {admissionNumber:this.parentAdmissionNumber};
      this.studentApiService.getStudent(this.id)
        .subscribe(studentdetails => {
          this._student = studentdetails;
          this.studentApiService.setFormValue(studentdetails);
          console.log(this._student);
          this.parentG={dependentsdetails:studentdetails.dependentsdetails};
          // this.dependentsdetails.emit({ value: this.dependentsdetails, valid: this.dependentsdetails });
        }, error => console.log(error));
    }
    else 
    {
      this.parentG = {dependentsdetails:[]};
    }
    
  }
  

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;
  }

  btnMovement(st: string) {
//debugger;
   let flg = this.dt.toArray()[this.selectedTab].formTouched();
   console.log(flg)
   
      if (st === 'bck') {
        this.selectedTab--;
      }
      else if (st === 'frd' && flg) {
        if (this.selectedTab == 1) {
          this.submit();
          return;
        }
        this.selectedTab++;
      }
    
  }

  submit(){

    this.blockUI.start();
    this.submitted = true;


  //  if (this.stuFormtDetails.includes(false)) {
  //      this.blockUI.stop();
  //     // return;
  //   }

    if (this.isAddMode) {
      this.createStudent();
     } else {
      this.updateStudent();
     }

     this.blockUI.stop();
  }

  createStudent()
  {
    console.log(JSON.stringify(this.stuJsonResult));
    this.studentApiService.createStudent(this.stuJsonResult).subscribe(admissionNumber=>{
      this.parentAdmissionNumber = admissionNumber;
      this.documentDetails = {admissionNumber:this.parentAdmissionNumber};
      this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"New Student created successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
        // this.router.navigate(['/student-list']);
        this.selectedTab++;
      }, 1000);
    });
  }

  updateStudent()
  {
    this.studentApiService.updateStudent(this.id, this.stuJsonResult).subscribe(_=>{
      this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"Student details updated successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
        // this.router.navigate(['/student-list']);
        this.selectedTab++;
      }, 1000);
    });
  }
  
  setTabFormDetails(value: any,tab:number){
    // if (!environment.production)
    //     debugger;
    this.stuFormtDetails[tab] = value.valid;
    Object.assign(this.stuJsonResult,value.value);
    console.log(value.value);

  }


}

