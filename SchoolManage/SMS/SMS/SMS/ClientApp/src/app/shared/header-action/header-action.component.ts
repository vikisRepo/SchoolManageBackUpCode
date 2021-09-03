import { DatePipe } from '@angular/common';
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { _MatTabBodyBase } from '@angular/material/tabs';
import { Router } from '@angular/router';
@Component({
  selector: 'app-header-action',
  templateUrl: './header-action.component.html',
  styleUrls: ['./header-action.component.css']
})
export class HeaderActionComponent implements OnInit {
  campaignTwo: FormGroup;
  @Input() index: number = 0;
  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  });
  constructor(private router: Router) {
   
   }
  

  // campaignTwo = new FormGroup({
  //   start: new FormControl(new Date(year, month, 15)),
  //   end: new FormControl(new Date(year, month, 19))
  // });
  ngOnInit(): void {
  }

  staffListOpen() {
    // this.stafflistOpen=true;
    // this.stafflist.emit(this.stafflistOpen);
    if (this.index === 1) {
      this.router.navigate(['staff-list']);
    }
    else if (this.index === 0) {
      this.router.navigate(['student-list']);
    }
    else if (this.index ===2){
      this.router.navigate(['e-letter-list']);
    }
    else if (this.index ===3){
      this.router.navigate(['staff-feedback-list']);
    }
    else if (this.index ===4){
      this.router.navigate(['student-feedback-list']);
    }
    else if (this.index ===18){
       this.router.navigate(['list-inventory'])
    }
  }
}
