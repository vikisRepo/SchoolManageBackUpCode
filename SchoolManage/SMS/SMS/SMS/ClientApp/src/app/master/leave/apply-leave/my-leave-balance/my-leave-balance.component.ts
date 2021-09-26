import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-my-leave-balance',
  templateUrl: './my-leave-balance.component.html',
  styleUrls: ['./my-leave-balance.component.css']
})
export class MyLeaveBalanceComponent implements OnInit {

  leaveblcform : FormGroup;
  constructor(public dialogRef: MatDialogRef<MyLeaveBalanceComponent>){ 
    
  }

  ngOnInit(): void {
  }

  close(val?: any) {
    if (!val) {
      this.dialogRef.close();
    }
  }
}
