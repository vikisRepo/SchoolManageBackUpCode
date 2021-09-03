import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators,NgForm  } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { StaffrestApiService } from '../staffrest-api.service';
import { ActivatedRoute } from '@angular/router';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { MatDialog } from '@angular/material/dialog';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';

@Component({
  selector: 'app-e-letter',
  templateUrl: './e-letter.component.html',
  styleUrls: ['./e-letter.component.css']
})
export class ELetterComponent implements OnInit,FormTouched {
  eletterfrm : FormGroup;
  letterTypes = SmsConstant.letterType;
  month = SmsConstant.months;
  years = SmsConstant.year;
  isAddMode?: boolean;
  loading = false;
  submitted = false;
  id?: any;

   @BlockUI() blockUI: NgBlockUI;

  constructor( private fb:FormBuilder, private staffrestApiService :StaffrestApiService, private route: ActivatedRoute, public dialog: MatDialog) {
      this.eletterfrm = this.fb.group({
        empid: ['', [Validators.required]],
        staffName:['', Validators.required],
        letterType:['',Validators.required],
        department:['', Validators.required],
        month:['', Validators.required],
        teacherId:['',Validators.required],
        year:['', Validators.required]
      });

   }
  formTouched(): boolean {
    this.eletterfrm.markAllAsTouched();
    return this.eletterfrm.valid;
  }


   ngAfterViewInit(): void {

    if(!this.isAddMode)
    {
      this.staffrestApiService.getStaffeLetter(this.id)
        .subscribe(data => {
          this.eletterfrm.patchValue(data);
        }, error => console.log(error));
    }
    
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;
  }

  submit() {
    this.eletterfrm.markAllAsTouched();
    if (this.eletterfrm.invalid) {
      // this.router.navigate([this.returnUrl]);
      return;

    }

    this.blockUI.start();
    this.submitted = true;

    if (this.isAddMode) {
      this.createStaffeLetter();
     } else {
      this.updateSatffeLetter();
     }

     this.blockUI.stop();


    
  }

  onFormSubmit(form:NgForm)  
  {  
    console.log(form);  
  }  


  createStaffeLetter()
  {
    this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"e-Letter detail created successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500);
    this.staffrestApiService.createStaffeLetter(this.eletterfrm.value).subscribe(_=>{      
    });
  }

  updateSatffeLetter()
  {
    this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"e-Letter detail updated successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500);
    this.staffrestApiService.updateStaffeLetter(this.id, this.eletterfrm.value).subscribe(_=>{
      this.staffrestApiService.createStaffeLetter(this.eletterfrm.value).subscribe(_=>{
       
        
        
      });
    });
  }
  onSubmit() {

    this.submitted = true;

    // stop here if form is invalid
    
    

      
  }

  get f() { return this.eletterfrm.controls; }
   
}
