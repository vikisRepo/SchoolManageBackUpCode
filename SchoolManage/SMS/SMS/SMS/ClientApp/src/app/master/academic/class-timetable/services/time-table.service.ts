import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable()
export class TimeTableService {

  timeTableData: any = {};

  private _emitClick = new Subject();
  getEventClick = this._emitClick.asObservable();

  constructor() { }

  set setData(obj) {
    this._emitClick.next(obj);
  }

}
