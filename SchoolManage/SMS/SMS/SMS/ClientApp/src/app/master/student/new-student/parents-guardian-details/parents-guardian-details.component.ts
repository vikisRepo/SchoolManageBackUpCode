import { ViewChildren } from '@angular/core';
import { QueryList } from '@angular/core';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';
import { PGFormComponent } from './p-g-form/p-g-form.component';

@Component({
  selector: 'app-parents-guardian-details',
  templateUrl: './parents-guardian-details.component.html',
  styleUrls: ['./parents-guardian-details.component.css']
})
export class ParentsGuardianDetailsComponent implements OnInit, FormTouched {
  @Output() stuFormtDetails = new EventEmitter();
  arryoffPersonJson: any = {
    fatherDetails: {},
    motherDetails: {},
    localGuardian: {},
    legalGuardian: {}
  };
  @ViewChildren("dt") dt: QueryList<FormTouched>;
  stuParentDetails: boolean[] = [false, false, false, false];
  constructor() { }

  formTouched(): boolean {
    // return this.stuParentDetails.reduce((pre: boolean, current) => pre && current, true);
    console.log(this.dt.length)
    let pre=true;
     this.dt.forEach((current) =>{
       let g =current.formTouched();
       pre= pre && g;
     });
     return pre;
  }

  ngOnInit(): void {
  }

  getParentsInfo(obj: any, flg: number) {
    this.stuParentDetails[flg] = obj.valid;
    switch (flg) {
      case 0: this.arryoffPersonJson.fatherDetails = obj.value;
        break;
      case 1: this.arryoffPersonJson.motherDetails = obj.value;
        break;
      case 2: this.arryoffPersonJson.localGuardian = obj.value;
        break;
      case 3: this.arryoffPersonJson.legalGuardian = obj.value;
        break;

    }
    console.log(true);
    console.log(this.arryoffPersonJson);
    console.log(this.stuParentDetails[flg]);
    this.stuFormtDetails.emit({ value: this.arryoffPersonJson, valid: this.stuParentDetails[flg] });
    // this.adderessArray[flg] = value;
    // this.addresses.emit(this.adderessArray);

  }
}
