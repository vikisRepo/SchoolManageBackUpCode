import { analyzeAndValidateNgModules } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AttendancerestApiService {

  constructor() { }
  getMyAttenance() {
    // return this.http.get<any>(this.apiFeedbackURL)
    // .pipe(
    //   retry(1),
    //   catchError((err)=>this.handleError(err))
    

    //)
  }
}
