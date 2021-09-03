import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

import { CompileShallowModuleMetadata } from '@angular/compiler';
import { Console } from 'console';
import { ClassGrade } from '../class-grade/models/class-grade';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class ClassGradeRestApiService {

  // apiURL = 'api/AcademicClass';

  apiURL =  environment.apiUrl+"/api/AcademicClass";
  
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


  getClassGrades(): Observable<ClassGrade> {
    return this.http.get<ClassGrade>(this.apiURL)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }

  getClassGrade(id : any): Observable<ClassGrade> {
    return this.http.get<ClassGrade>(this.apiURL + '/' + id)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }  


  createClassGrade(staff : any): Observable<ClassGrade> {
    console.log(JSON.stringify(staff));
    return this.http.post<any>(this.apiURL, JSON.stringify(staff), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )

  }  

  updateClassGrade(id : any, staff : ClassGrade): Observable<ClassGrade> {
    return this.http.put<ClassGrade>(this.apiURL +'/'+ id, JSON.stringify(staff))
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }

  // HttpClient API delete() method => Delete ClassGrade
  deleteClassGrade(id : any){
    return this.http.delete<ClassGrade>(this.apiURL + '/'+ id, this.httpOptions)
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
