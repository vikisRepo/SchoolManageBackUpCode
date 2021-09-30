import { Component, OnInit, Output,EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';

@Component({
  selector: 'app-leave-configuration',
  templateUrl: './leave-configuration.component.html',
  styleUrls: ['./leave-configuration.component.css']
})
export class LeaveConfigurationComponent implements OnInit {

  leaveForm : FormGroup;
  staffLeave: FormGroup;
  enabletrashForStudentLeave : any = true;
  enabletrashForStaffLeave : any = true;

  @Output() formDetails=new EventEmitter();

  get studentLeave() : FormArray {
    return this.leaveForm.get('studentLeave') as FormArray;
  };

  get staffLeavearr(): FormArray {
    return this.leaveForm.get('staffLeavearr') as FormArray;
  };

  constructor(private fb : FormBuilder) {
    this.leaveForm = this.fb.group({
      studentLeave: this.fb.array([this.buildStudentLeave()]),
     // staffLeave: this.fb.array([this.buildStaffLeave]),
      // staffLeave : this.fb.group({
        staffLeavearr : this.fb.array([this.buildStaffLeave])
      // })
    });

    // this.leaveForm.valueChanges.subscribe(()=>{
    //   this.formDetails.emit({ value: this.leaveForm.value,
    //            valid: this.leaveForm.valid });
    // });

    // this.staffLeave.valueChanges.subscribe(()=>{
    //   this.formDetails.emit({ value: this.staffLeave.value,
    //            valid: this.staffLeave.valid });
    // });
   }

  ngOnInit(): void {
  }

  addStudentleave(): void {
    this.studentLeave.push(this.buildStudentLeave());
  }

  addStaffleave(): void {
    this.staffLeavearr.push(this.buildStaffLeave());
  }

  buildStudentLeave(): FormGroup {
    return this.fb.group({
      studentLeave: ['', Validators.required]
    });
    
  }
  buildStaffLeave(): FormGroup {
    return this.fb.group({
      staffLeave: ['', Validators.required]
    });
    
  }

  deleteForStudentLeave(index: number)
  {
    //console.log(this.studentLeave.at(index).value.inventoryDefectId);
    // this.inventoryDefectService.deleteInventoryDefects(this.defect.at(index).value.inventoryDefectId).subscribe( _=> {
    //   this.dialog.open(MessageBoxComponent, { width: '350px', height: '100px', data: "Inventory Details deleted successfully !" });
    //   setTimeout(() => {
    //     this.defect.removeAt(index);
    //     this.dialog.closeAll();
    //   }, 5000);
    // });
  }

  changeandunchangeForStudentLeave(flg:boolean , index : number){
    // if(flg)
    //   {
    //     console.log(this.defect.at(index).value)
    //    this.CreateInventoryDefect(this.defect.at(index).value);
    //     this.defect.at(index).disable();
    //   }
    // else{
    //     this.defect.at(index).enable();
    // }
  }

  deleteForStaffLeave(index: number)
  {
    //console.log(this.studentLeave.at(index).value.inventoryDefectId);
    // this.inventoryDefectService.deleteInventoryDefects(this.defect.at(index).value.inventoryDefectId).subscribe( _=> {
    //   this.dialog.open(MessageBoxComponent, { width: '350px', height: '100px', data: "Inventory Details deleted successfully !" });
    //   setTimeout(() => {
    //     this.defect.removeAt(index);
    //     this.dialog.closeAll();
    //   }, 5000);
    // });
  }

  changeandunchangeForStaffLeave(flg:boolean , index : number){
    // if(flg)
    //   {
    //     console.log(this.defect.at(index).value)
    //    this.CreateInventoryDefect(this.defect.at(index).value);
    //     this.defect.at(index).disable();
    //   }
    // else{
    //     this.defect.at(index).enable();
    // }
  }

}
