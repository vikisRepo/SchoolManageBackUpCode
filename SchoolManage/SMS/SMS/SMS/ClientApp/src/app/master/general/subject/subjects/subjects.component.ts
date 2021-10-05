import { Component, Input,EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { FactorydataService } from 'src/app/shared/factorydata.service';
import { Subject } from '../Models/subject';
import { SubjectRestApiService } from '../subject-rest-api.service';

@Component({
  selector: 'app-subjects',
  templateUrl: './subjects.component.html',
  styleUrls: ['./subjects.component.css']
})
export class SubjectsComponent implements OnInit {
 @Input() expData:any;
 @Output() btnEvent =new EventEmitter();

 newFlag:boolean=false;
 subjectForm: FormGroup;
  constructor(private fb: FormBuilder, private subjectApi : SubjectRestApiService, 
    private factory: FactorydataService, public dialog: MatDialog) {
    
    this.subjectForm = this.fb.group({
      subjectDescr :[, Validators.required],
      subjectID :[0]
    })
   }

  ngOnInit(): void {

    if (Object.keys(this.expData).length != 0) {

      this.subjectForm.disable();
      this.subjectForm.setValue(this.expData);
    }
    else{

      this.newFlag=true;
    }

  }

  save() {

    if (Object.keys(this.expData).length != 0)
    {
      this.update();
      return;
    }


    this.subjectApi.createSubject(this.subjectForm.value).subscribe(_=>{
      this.btnEvent.emit();
      this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"New Subject saved successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
        this.factory.Loadfactorydata();
      }, 1000);
    });

  }

  delete() {
    
    if (!this.expData?.subjectDescr) {
      this.btnEvent.emit(1);
      return;
    }
    
    this.subjectApi.deleteSubject(this.expData.subjectID).subscribe(_=>{
      this.btnEvent.emit();
      this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"Subject deleted successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
        this.factory.Loadfactorydata();
      }, 1000);
    });

  }

  update()
  {
    this.subjectApi.updateSubject(this.expData.subjectID, this.subjectForm.value).subscribe(_=>{
      this.btnEvent.emit();
      this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"Subject updated successfully !"});
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
    this.newFlag = true;
    this.subjectForm.enable();

    this.btnEvent.emit(2);
  }

}
