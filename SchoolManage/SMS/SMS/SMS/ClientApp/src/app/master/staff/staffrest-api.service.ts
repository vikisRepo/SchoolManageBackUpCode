import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, Subject, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

import { CompileShallowModuleMetadata } from '@angular/compiler';
import { Console } from 'console';
import { Staff } from './Staff';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StaffrestApiService {
  @BlockUI() blockUI: NgBlockUI;
  //apiURL = 'api/Staff';
  apiURL = environment.apiUrl + '/api/Staff';
  apieLetterURL = 'api/api/StaffeLetter';
  apiFeedbackURL = 'api/StaffFeedback';

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
  getStaffs(): Observable<Staff> {
    return this.http.get<Staff>(this.apiURL)
    .pipe(
      retry(1),
      catchError((err)=>this.handleError(err))
    )
  }

  // HttpClient API get() method => Fetch Staff
  getStaff(id : any): Observable<Staff> {
    return this.http.get<Staff>(this.apiURL + '/' + id)
    .pipe(
      retry(1),
      catchError((err)=>this.handleError(err))
    )
  }  

  // HttpClient API post() method => Create Staff
  createStaff(staff : Staff): Observable<Staff> {
    console.log(JSON.stringify(staff))
    return this.http.post<Staff>(this.apiURL ,staff, this.httpOptions)
    .pipe(
      retry(1),
      catchError((err)=>this.handleError(err))
    )

  }  

  // HttpClient API put() method => Update Staff
  updateStaff(id : any, staff : Staff): Observable<Staff> {
    return this.http.put<Staff>(this.apiURL + '/' + id, JSON.stringify(staff), this.httpOptions)
    .pipe(
      retry(1),
      catchError((err)=>this.handleError(err))
    )
  }

  // HttpClient API delete() method => Delete Staff
  deleteStaff(id : any){
    return this.http.delete<Staff>(this.apiURL + '/'+ id, this.httpOptions)
    .pipe(
      retry(1),
      catchError((err)=>this.handleError(err))
    )
  }

  //Staff-Feedback
    // HttpClient API get() method => Fetch Staffs list
    getStaffsFeedBack(): Observable<any> {
      return this.http.get<any>(this.apiFeedbackURL)
      .pipe(
        retry(1),
        catchError((err)=>this.handleError(err))
      )
    }
  
    // HttpClient API get() method => Fetch Staff
    getStaffFeedBack(id : any): Observable<any> {
      return this.http.get<any>(this.apiFeedbackURL + '/' + id)
      .pipe(
        retry(1),
        catchError((err)=>this.handleError(err))
      )
    }  
  
    // HttpClient API post() method => Create Staff
    createStaffFeedBack(staffFeedBack : any): Observable<any> {
      console.log(JSON.stringify(staffFeedBack))
      return this.http.post<any>(this.apiFeedbackURL ,staffFeedBack, this.httpOptions)
      .pipe(
        retry(1),
        catchError((err)=>this.handleError(err))
      )
  
    }  
  
    // HttpClient API put() method => Update Staff
    updateStaffFeedBack(id : any, staffFeedBack : Staff): Observable<any> {
      return this.http.put<any>(this.apiFeedbackURL + '/' + id, JSON.stringify(staffFeedBack), this.httpOptions)
      .pipe(
        retry(1),
        catchError((err)=>this.handleError(err))
      )
    }
  
    // HttpClient API delete() method => Delete Staff
    deleteStaffFeedBack(id : any){
      return this.http.delete<any>(this.apiFeedbackURL + '/'+ id, this.httpOptions)
      .pipe(
        retry(1),
        catchError((err)=>this.handleError(err))
      )
    }
// end Staff FeedBack


//Staff-eLetter
    // HttpClient API get() method => Fetch Staffs list
    getStaffseLetters(): Observable<any> {
      return this.http.get<any>(this.apieLetterURL)
      .pipe(
        retry(1),
        catchError((err)=>this.handleError(err))
      )
    }
  
    // HttpClient API get() method => Fetch Staff
    getStaffeLetter(id : any): Observable<any> {
      return this.http.get<any>(this.apieLetterURL + '/' + id)
      .pipe(
        retry(1),
        catchError((err)=>this.handleError(err))
      )
    }  
  
    // HttpClient API post() method => Create Staff
    createStaffeLetter(staffFeedBack : any): Observable<any> {
      console.log(JSON.stringify(staffFeedBack))
      return this.http.post<any>(this.apieLetterURL ,staffFeedBack, this.httpOptions)
      .pipe(
        retry(1),
        catchError((err)=>this.handleError(err))
      )
  
    }  
  
    // HttpClient API put() method => Update Staff
    updateStaffeLetter(id : any, staffFeedBack : Staff): Observable<any> {
      return this.http.put<any>(this.apieLetterURL + '/' + id, JSON.stringify(staffFeedBack), this.httpOptions)
      .pipe(
        retry(1),
        catchError((err)=>this.handleError(err))
      )
    }
  
    // HttpClient API delete() method => Delete Staff
    deleteStaffeLetter(id : any){
      return this.http.delete<any>(this.apieLetterURL + '/'+ id, this.httpOptions)
      .pipe(
        retry(1),
        catchError((err)=>this.handleError(err))
      )
    }
//


  // Error handling 
  handleError(error: any) {
        this.blockUI.stop();
     

     let errorMessage = '';
     if(error.error instanceof ErrorEvent) {
       // Get client-side error
       errorMessage = error.error.message;
     } else {
       // Get server-side error
       errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
     }
     window.alert(errorMessage);
     return throwError(errorMessage);
  }
  setFormValue(value:any) {
    this.formvalueSource.next(value);
  }
}
