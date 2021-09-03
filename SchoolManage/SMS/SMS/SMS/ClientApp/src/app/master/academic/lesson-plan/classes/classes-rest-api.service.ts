import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { ClassGrade } from 'src/app/master/general/class-grade/models/class-grade';

@Injectable({
  providedIn: 'root'
})
export class ClassesRestApiService {

  apiURL = 'api/api/AcademicClass/GetClassNames/';
  //apiURL = "http://localhost:4000/Classes";
  
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


  getClassGrade(): Observable<any> {
    return this.http.get<any>(this.apiURL)
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
