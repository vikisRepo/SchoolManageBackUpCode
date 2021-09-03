import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { LessonPlan } from './models/lesson-plan';

@Injectable({
  providedIn: 'root'
})
export class LessonPlanRestApiService {

  // apiURL = 'api/AcademicClass/GetClassSubjects/';
  apiURL = environment.apiUrl + "/api/AcademicClass/";
  // lessonPlanURL = 'api/LessonPlan/';

  lessonPlanURL =  "http://localhost:3007/LessonPlan";

  coursePlanURL = 'api/Course/';
  
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


  getClassSubjects(className : any): Observable<any> {
    return this.http.get<any>(this.apiURL + className)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  } 

  // HttpClient API post() method => Create LessonPlan
  createLessonPlan(lessonPlan : any): Observable<any> {

    return this.http.post<any>(this.lessonPlanURL,lessonPlan, this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )

  }  

  // HttpClient API post() method => Create LessonPlan
  createCourse(course : any): Observable<any> {

    return this.http.post<any>(this.coursePlanURL,course, this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )

  }  

  getLessonPlans(): Observable<any> {
    return this.http.get<any>(this.lessonPlanURL)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }

  getLessonPlan(id : any): Observable<any> {
    return this.http.get<any>('/api/api/LessonPlan/GetLessonPlan/' + id)
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
