import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SmsConstant } from 'src/app/shared/constant-values';
import { FactorydataService } from 'src/app/shared/factorydata.service';
import { TimeTableService } from '../services/time-table.service';

@Component({
  selector: 'app-time-table-editor',
  templateUrl: './time-table-editor.component.html',
  styleUrls: ['./time-table-editor.component.css']
})
export class TimeTableEditorComponent implements OnInit {
  
  @Input() public classdetails : any;
  subjects = SmsConstant.Subjectsdropdown;
  staff = SmsConstant.staffName;

  slotForm: FormGroup;

  constructor(private fb: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private ttObj: TimeTableService,
    public dialogRef: MatDialogRef<TimeTableEditorComponent>,private factory: FactorydataService) { 
      this.subjects = factory.Subjectsdropdown;
      this.staff = factory.staffNames;
    }

  ngOnInit(): void {
  
  
    this.slotForm = this.fb.group({
      subject: ['', [Validators.required]],
      staff: ['', [Validators.required]],
      startTime: ['', [Validators.required]],
      endTime: ['', [Validators.required]]
    });

    if(this.data){
      console.log(this.data)
    
      this.slotForm.patchValue(this.data);
    }

  }

  close(val?: any) {
    if (!val) {
      this.dialogRef.close();
    }
    else {

    }
  }


}
