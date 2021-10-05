import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { SmsConstant } from 'src/app/shared/constant-values';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { FactorydataService } from 'src/app/shared/factorydata.service';
import { ClassGradeRestApiService } from '../class-grade-rest-api.service';

@Component({
  selector: 'app-class-section',
  templateUrl: './class-section.component.html',
  styleUrls: ['./class-section.component.css']
})
export class ClassSectionComponent implements OnInit {

  @Input() expData: any;
  @Output() btnEvent = new EventEmitter();

  // subjectList=SmsConstant.Subjectsdropdown;
  // sectionList=SmsConstant.Sectiondropdown;
  _eventtype : any;
  newFlag:boolean=false;
  sectionList: string[] = ['A', 'B', 'C', 'D', 'E', 'F'];
  subjectList = SmsConstant.Subjectsdropdown;
  csForm: FormGroup;

  constructor(private fb: FormBuilder, private classGradeRestApiService :ClassGradeRestApiService, private factory: FactorydataService,
    public dialog: MatDialog) {
    this.subjectList = factory.Subjectsdropdown;
    this.csForm = this.fb.group({
      class: ['', Validators.required],
      subjects: ['', Validators.required],
      sections: ['', Validators.required],
      group: ['', Validators.required],
      academicYear: [Date.now]
    });

  }

  ngOnInit(): void {
    this._eventtype = 'toggle';
    if (Object.keys(this.expData).length != 0) {
      this.csForm.disable();
      this.csForm.setValue(this.expData);
    }
    else{
      this.newFlag=true;
      this._eventtype = 'toggle';
    }
  }

  save(eventtype : any) {
    
    if (Object.keys(this.expData).length != 0)
    {
      if (eventtype == 'toggle')
      {
        this.newFlag = false;
        this.csForm.enable();
        this._eventtype = 'update';
        return;
      }

      if (eventtype == 'update')
      {
        this.update();
        this._eventtype = 'toggle';
        return;
      }
    }

    console.log(this.csForm.value);
    this.classGradeRestApiService.createClassGrade(this.csForm.value).subscribe(_=>{
      this.btnEvent.emit();
      this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"Class has been created successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
        this.factory.Loadfactorydata();
      }, 1000);
    });

 }

  delete() {
    
    // console.log('first');
    // if (!this.expData?.subjectDescr) {
    //   this.btnEvent.emit(1);
    //   return;
    // }

    // console.log('second');
    
    this.classGradeRestApiService.deleteClassGrade(this.expData.class).subscribe(_=>{
      this.btnEvent.emit();
      this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"Class has been deleted successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
        this.factory.Loadfactorydata();
      }, 1000);
    });

  }

  update()
  {
    this.classGradeRestApiService.updateClassGrade(this.expData.class, this.csForm.value).subscribe(_=>{
      this.btnEvent.emit();
      this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"Class has been updated successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
        this.factory.Loadfactorydata();
      }, 1000);
    });

  }

  cancel() {

    this.btnEvent.emit();

  }

  toggleButton()
  {
    this.newFlag = false;
    this.csForm.enable();

    this.btnEvent.emit(2);
  }
}
