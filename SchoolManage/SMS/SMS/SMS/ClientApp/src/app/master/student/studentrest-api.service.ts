import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders, HttpParams, HttpRequest } from '@angular/common/http';
import { Observable, Subject, throwError } from 'rxjs';
import { retry, catchError, delay } from 'rxjs/operators';

import { CompileShallowModuleMetadata } from '@angular/compiler';
import { Console } from 'console';
import { Student, Dependents } from './student';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { environment } from 'src/environments/environment';
import { DatePipe } from '@angular/common';
import { formatDate } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class StudentrestApiService {

  apiURL = environment.apiUrl + '/api/Student';
  apiFeedbackURL = environment.apiUrl +'/api/StudentFeedback/';
  studocsapiURL = environment.apiUrl + '/api/UploadDownload/GetStudentDocumentDetails';
  apiStudentFeedbackUploadUrl = environment.apiUrl + '/api/StudentFeedback/UploadStudentFeedbackAndDocument'; 
  
  @BlockUI() blockUI: NgBlockUI;

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

  // HttpClient API get() method => Fetch Students list
  getStudents(): Observable<Student> {
    return this.http.get<Student>(this.apiURL)
    .pipe(
      retry(1),
      catchError((err)=>this.handleError(err))
    )
  }

  // HttpClient API get() method => Fetch Student
  getStudent(id : any): Observable<any> {
    return this.http.get<any>(this.apiURL + '/' + id)
    .pipe(
      retry(1),
      catchError((err)=>this.handleError(err))
    )
  }  

  // HttpClient API get() method => Fetch Student
  GetStudentDocumentDetails(admissionNumber : any, docType : any): Observable<any> {
    return this.http.get<any>(this.studocsapiURL + '/' + admissionNumber + '/' + docType)
    .pipe(
      retry(1),
      catchError((err)=>this.handleError(err)),
      delay(1000) 
    )
  }  

  // HttpClient API post() method => Create Student
  createStudent(student : Student): Observable<any> {
    console.log(JSON.stringify(student));
    return this.http.post<Student>(this.apiURL,student, this.httpOptions)
    .pipe(
      retry(1),
      catchError((err)=>this.handleError(err))
    )

  }  

  // HttpClient API put() method => Update Student
  updateStudent(id : any, student : Student): Observable<Student> {
    return this.http.put<Student>(this.apiURL +'/'+ id, student, this.httpOptions)
    .pipe(
      retry(1),
      catchError((err)=>this.handleError(err))
    )
  }

  // HttpClient API delete() method => Delete Student
  deleteStudent(id : any){
    return this.http.delete<Student>(this.apiURL + '/' + id, this.httpOptions)
    .pipe(
      retry(1),
      catchError((err)=>this.handleError(err))
    )
  }

  //Staff-Feedback
    // HttpClient API get() method => Fetch Staffs list
    getStudentsFeedBack(): Observable<any> {
      return this.http.get<any>(this.apiFeedbackURL)
      .pipe(
        retry(1),
        catchError((err)=>this.handleError(err))
      )
    }

    getStudentsFeedBackByAdmissionNumber(admissionNumber : any): Observable<any> {
      console.log(this.apiFeedbackURL + "GetByAdmissionNumber/" + admissionNumber);
      return this.http.get<any>(this.apiFeedbackURL + "GetByAdmissionNumber/" + admissionNumber)
      .pipe(
        retry(1),
        catchError((err)=>this.handleError(err))
      )
    }
  
    // HttpClient API get() method => Fetch Staff
    getStudentFeedBack(id : any): Observable<any> {
      return this.http.get<any>(this.apiFeedbackURL + '/' + id)
      .pipe(
        retry(1),
        catchError((err)=>this.handleError(err))
      )
    }  
  
    // // HttpClient API post() method => Create Staff
    // createStudentFeedBack(staffFeedBack : any): Observable<any> {
    //   console.log(JSON.stringify(staffFeedBack))
    //   return this.http.post<any>(this.apiFeedbackURL ,staffFeedBack, this.httpOptions)
    //   .pipe(
    //     retry(1),
    //     catchError((err)=>this.handleError(err))
    //   )
  
    // }
    
    public createStudentFeedBack(file: Blob, studentFeedbackdetails : any): Observable<HttpEvent<void>> {
      debugger;
      console.log("Hai"+studentFeedbackdetails.startDate.toISOString());
      const formData = new FormData();
      formData.append('file', file);
      // formData.append('studentAttachments', JSON.stringify(docdetails));
      formData.append('admissionNumber', studentFeedbackdetails.admissionNumber);
      formData.append('staffId', studentFeedbackdetails.staffId);
      formData.append('feedbackType', studentFeedbackdetails.feedbackType);
      formData.append('date',  studentFeedbackdetails.startDate.toISOString());// | date: "dd:MMM:yyyy hh-mm-ss z"
      formData.append('class', studentFeedbackdetails.class);
      formData.append('feedbacktitle', studentFeedbackdetails.feedbacktitle);
      formData.append('section', studentFeedbackdetails.section);
      formData.append('description', studentFeedbackdetails.description);

      let stuparams= new HttpParams()
      stuparams.set('admissionNumber', studentFeedbackdetails.admissionNumber);
      stuparams.set('staffId', studentFeedbackdetails.staffId);
      stuparams.set('feedbackType', studentFeedbackdetails.feedbackType);
      stuparams.set('date', studentFeedbackdetails.date);
      stuparams.set('class', studentFeedbackdetails.class);
      stuparams.set('feedbacktitle', studentFeedbackdetails.feedbacktitle);
      stuparams.set('section', studentFeedbackdetails.section);
      stuparams.set('description', studentFeedbackdetails.description);

      return this.http.request(new HttpRequest(
        'POST',
        this.apiStudentFeedbackUploadUrl,
        formData,
        {
          reportProgress: true,
          params: stuparams
        }));
    }
  
    // HttpClient API put() method => Update Staff
    updateStudentFeedBack(id : any, staffFeedBack : any): Observable<any> {
      return this.http.put<any>(this.apiFeedbackURL + '/' + id, JSON.stringify(staffFeedBack), this.httpOptions)
      .pipe(
        retry(1),
        catchError((err)=>this.handleError(err))
      )
    }
  
    // HttpClient API delete() method => Delete Staff
    deleteStudentFeedBack(id : any){
      return this.http.delete<any>(this.apiFeedbackURL + '/'+ id, this.httpOptions)
      .pipe(
        retry(1),
        catchError((err)=>this.handleError(err))
      )
    }
// end Staff FeedBack

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
