import { Component, OnInit, Output, EventEmitter, Input, SimpleChanges, ViewChildren, QueryList } from '@angular/core';
import { FormTouched } from '../../interfaces/form-touched';


@Component({
  selector: 'app-address-details',
  templateUrl: './address-details.component.html',
  styleUrls: ['./address-details.component.css']
})
export class AddressDetailsComponent implements OnInit, FormTouched {

  formPermanentAddress: any = {};
  formCurrentAddress: any = {};

  adderessArray = [{ value: {}, valid: false }, { value: {}, valid: false }];
  cTpFlag: boolean = false;

  @Output() addresses = new EventEmitter();
  @Input() addressDetails;

  @ViewChildren('formTouched') formTouchedObj: QueryList<FormTouched>;

  constructor() {

  }

  formTouched(): boolean {
    let f: boolean = this.formTouchedObj.reduce((p: boolean, c: FormTouched) => {
      let k = c.formTouched();
      console.log(k)
      return p && k;
    }, true);
    return f;
  }

  ngOnChanges(changes: SimpleChanges): void {

    if (changes.addressDetails.currentValue) {
      this.formCurrentAddress = this.addressDetails[0];

      this.formPermanentAddress = this.addressDetails[1];
    }
  }

  ngOnInit(): void {
  }

  cTp(flag: boolean) {
    if (flag) {
      this.cTpFlag = true;
      this.formPermanentAddress = this.adderessArray[0].value;
      this.adderessArray[1] = this.adderessArray[0];

      this.addresses.emit(this.adderessArray);
      return;
    }
    this.cTpFlag = false;
  }

  getAddress(value: any, flg: number) {
    if (this.cTpFlag && flg == 1) {

      return;
    }
    this.adderessArray[flg] = value;
    this.addresses.emit(this.adderessArray);
  }

}
