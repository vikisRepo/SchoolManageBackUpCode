import { Input, SimpleChanges, ViewChildren } from '@angular/core';
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
  @Input() getFormValues = {};
  @Input() arryoffPersonJson : any = {
    dependentsdetails: [4],
    // motherDetails: {},
    // localGuardian: {},
    // legalGuardian: {}
  };
  @ViewChildren("dt") dt: QueryList<FormTouched>;
  @ViewChildren('dt') pgFroms:QueryList<PGFormComponent>;
  stuParentDetails: boolean[] = [false, false, false, false];
  constructor() {
   }

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
  
  ngOnChanges(changes: SimpleChanges): void {
    //debugger;
    console.log("json" + JSON.stringify(this.getFormValues));
    if(changes?.arryoffPersonJson){
     // console.log(this.arryoffPersonJson)
      setTimeout(()=>{
        let g=this.pgFroms.toArray();
        console.log(g.length,g[0]);
        g[0].parents.disable(); 
        g[0].parenttoggle = false;
        g[1].parents.disable(); 
        g[1].parenttoggle = false;
        g[2].parents.disable(); 
        g[2].parenttoggle = false;
        g[3].parents.disable(); 
        g[3].parenttoggle = false;
        this.arryoffPersonJson.dependentsdetails.forEach((element,index) => {
        g[index].parents.enable();  
        g[index].parenttoggle = true;
        g[index].parents.patchValue(element);
      });},30)
    
    }
   // this.arryoffPersonJson.dependentsdetails=this.getFormValues["dependentsdetails"];
  }

  getParentsInfo(obj: any, flg: number) {
    if (!obj.disabled) {
      this.stuParentDetails[flg] = obj.valid;
      switch (flg) {
        case 0: this.arryoffPersonJson.dependentsdetails[flg] = obj.value;
          break;
        case 1: this.arryoffPersonJson.dependentsdetails[flg] = obj.value;
          break;
        case 2: this.arryoffPersonJson.dependentsdetails[flg] = obj.value;
          break;
        case 3: this.arryoffPersonJson.dependentsdetails[flg] = obj.value;
          break;
      }
      this.stuFormtDetails.emit({ value: this.arryoffPersonJson, valid: this.stuParentDetails[flg] });
    }
  }
}
