import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

import { CompileShallowModuleMetadata } from '@angular/compiler';
import { Console } from 'console';
import { Subject } from '../subject/Models/subject';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class SubjectRestApiService {

 // apiURL = 'api/Subject';
    apiURL = environment.apiUrl + '/api/Subject';
  
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

  // HttpClient API get() method => Fetch Subject list
  getSubjects(): Observable<Subject> {
    //alert(this.apiURL);
    return this.http.get<Subject>(this.apiURL)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }

  // HttpClient API get() method => Fetch Subject
  getSubject(id : any): Observable<Subject> {
    return this.http.get<Subject>(this.apiURL + '/' + id)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }  

  // HttpClient API post() method => Create Subject
  createSubject(staff : any): Observable<Subject> {
    console.log(staff);
    return this.http.post<Subject>(this.apiURL,staff, this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )

  }  

  // HttpClient API put() method => Update Subject
  updateSubject(id : any, staff : Subject): Observable<Subject> {
    return this.http.put<Subject>(this.apiURL +'/'+ id, JSON.stringify(staff), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }

  // HttpClient API delete() method => Delete Subject
  deleteSubject(id : any){
    return this.http.delete<Subject>(this.apiURL + '/'+ id, this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }

  // Error handling 
  handleError(error: any) {
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

}

