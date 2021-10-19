import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpRequest } from '@angular/common/http';
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
  apiFeedbackURL = environment.apiUrl + '/api/StaffFeedback';
  apiFeedbackByEmployeeURL = environment.apiUrl + '/api/StaffFeedback/GetFeedbackByAccount';
  apiStaffFeedbackUploadUrl = environment.apiUrl + '/api/StaffFeedback/UploadStaffFeedbackAndDocument';
  apiStaffFeedbackUpdateUrl= environment.apiUrl + '/api/StaffFeedback/UpdateStaffFeedbackAndDocument';

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

    getStaffsFeedBackByAccount(id : any): Observable<any> {
      return this.http.get<any>(this.apiFeedbackByEmployeeURL + '/' + id)
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
    createStaffFeedBack(file: Blob, staffFeedBack : any): Observable<any> {
      debugger;
      const formData = new FormData();
      formData.append('file', file);
      // formData.append('studentAttachments', JSON.stringify(docdetails));
      formData.append('empid', staffFeedBack.empid);
      formData.append('staffName', staffFeedBack.staffName);
      formData.append('feedbackType', staffFeedBack.feedbackType);
      formData.append('date',  staffFeedBack.date.toISOString());// | date: "dd:MMM:yyyy hh-mm-ss z"
      formData.append('department', staffFeedBack.department);
      formData.append('feedbacktitle', staffFeedBack.feedbacktitle);
      formData.append('teacherId', staffFeedBack.teacherId);
      formData.append('description', staffFeedBack.description);

      // let stuparams= new HttpParams()
      // stuparams.set('admissionNumber', staffFeedBack.admissionNumber);
      // stuparams.set('staffId', staffFeedBack.staffId);
      // stuparams.set('feedbackType', staffFeedBack.feedbackType);
      // stuparams.set('date', staffFeedBack.date);
      // stuparams.set('class', staffFeedBack.class);
      // stuparams.set('feedbacktitle', staffFeedBack.feedbacktitle);
      // stuparams.set('section', staffFeedBack.section);
      // stuparams.set('description', staffFeedBack.description);

      return this.http.request(new HttpRequest(
        'POST',
        this.apiStaffFeedbackUploadUrl,
        formData,
        {
          reportProgress: true
          // params: stuparams
        }));
  
    }  
  
    // HttpClient API put() method => Update Staff
    // HttpClient API put() method => Update Staff
    updateStaffFeedBack(id : any, file: Blob, staffFeedBack : any): Observable<any> {
      const formData = new FormData();
      formData.append('file', file);
      // formData.append('studentAttachments', JSON.stringify(docdetails));
      formData.append('empid', staffFeedBack.empid);
      formData.append('staffFeedbackID', id);
      formData.append('staffName', staffFeedBack.staffName);
      formData.append('feedbackType', staffFeedBack.feedbackType);
      formData.append('date',  staffFeedBack.date);// | date: "dd:MMM:yyyy hh-mm-ss z"
      formData.append('department', staffFeedBack.department);
      formData.append('feedbacktitle', staffFeedBack.feedbacktitle);
      formData.append('teacherId', staffFeedBack.teacherId);
      formData.append('description', staffFeedBack.description);

      let stuparams= new HttpParams()
      // stuparams.set('admissionNumber', studentFeedbackdetails.admissionNumber); StudentFeedbackId
      // stuparams.set('staffId', studentFeedbackdetails.staffId);
      // stuparams.set('feedbackType', studentFeedbackdetails.feedbackType);
      // stuparams.set('date', studentFeedbackdetails.date);
      // stuparams.set('class', studentFeedbackdetails.class);
      // stuparams.set('feedbacktitle', studentFeedbackdetails.feedbacktitle);
      // stuparams.set('section', studentFeedbackdetails.section);
      // stuparams.set('description', studentFeedbackdetails.description);

      return this.http.request(new HttpRequest(
        'PUT',
        this.apiStaffFeedbackUpdateUrl,
        formData,
        {
          reportProgress: true,
          params: stuparams
        }));
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
      createStaffeLetter(file: Blob, staffFeedBack : any): Observable<any> {
        debugger;
        const formData = new FormData();
        formData.append('file', file);
        // formData.append('studentAttachments', JSON.stringify(docdetails));
        formData.append('empid', staffFeedBack.empid);
        formData.append('staffName', staffFeedBack.staffName);
        formData.append('feedbackType', staffFeedBack.feedbackType);
        formData.append('department', staffFeedBack.department);
        formData.append('feedbacktitle', staffFeedBack.feedbacktitle);
        formData.append('teacherId', staffFeedBack.teacherId);
        formData.append('description', staffFeedBack.description);
  
        // let stuparams= new HttpParams()
        // stuparams.set('admissionNumber', staffFeedBack.admissionNumber);
        // stuparams.set('staffId', staffFeedBack.staffId);
        // stuparams.set('feedbackType', staffFeedBack.feedbackType);
        // stuparams.set('date', staffFeedBack.date);
        // stuparams.set('class', staffFeedBack.class);
        // stuparams.set('feedbacktitle', staffFeedBack.feedbacktitle);
        // stuparams.set('section', staffFeedBack.section);
        // stuparams.set('description', staffFeedBack.description);
  
        return this.http.request(new HttpRequest(
          'POST',
          this.apiStaffFeedbackUploadUrl,
          formData,
          {
            reportProgress: true
            // params: stuparams
          }));
    
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
