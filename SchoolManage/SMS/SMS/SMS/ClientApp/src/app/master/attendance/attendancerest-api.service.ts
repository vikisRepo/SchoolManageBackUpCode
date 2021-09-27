import { HttpClient, HttpHeaders } from '@angular/common/http';
import { analyzeAndValidateNgModules } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { Observable, Subject, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AttendancerestApiService {

  @BlockUI() blockUI: NgBlockUI;
  //apiURL = 'api/Staff';
  apiURL = environment.apiUrl + '/api/attendance/';

  private formvalueSource = new Subject<string>();
  formValue$ = this.formvalueSource.asObservable();

  constructor(private http: HttpClient) { }

  /*========================================
    CRUD Methods for consuming RESTful API
  =========================================*/

  // Http Options
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  // HttpClient API get() method => Fetch Staffs list
  SearchStaffbyDepartmentAndStaffType(searchrequest : any): Observable<any> {
    return this.http.post<any>(this.apiURL + 'SearchStaffbyDepartmentAndStaffType', searchrequest, this.httpOptions)
      .pipe(
        retry(1),
        catchError((err) => this.handleError(err))
      )
  }

  // Error handling 
  handleError(error: any) {
    this.blockUI.stop();
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }
}
