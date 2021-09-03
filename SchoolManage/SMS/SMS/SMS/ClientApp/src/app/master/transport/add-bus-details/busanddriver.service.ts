import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { Observable, Subject, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BusanddriverService {

  apiURL = environment.apiUrl + '/api/BusAnddriver/';
  apiFeedbackURL = 'api/BusAnddriverFeedback/';

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

  // HttpClient API get() method => Fetch Busdrivers list
  getBusAnddrivers(): Observable<any> {
    return this.http.get<any>(this.apiURL)
      .pipe(
        retry(1),
        catchError((err) => this.handleError(err))
      )
  }

  // HttpClient API get() method => Fetch BusAnddriver
  getBusAnddriver(id: any): Observable<any> {
    return this.http.get<any>(this.apiURL + id)
      .pipe(
        retry(1),
        catchError((err) => this.handleError(err))
      )
  }

  // HttpClient API post() method => Create BusAnddriver
  createBusAnddriver(BusAnddriver: any): Observable<any> {
    // console.log(JSON.stringify(BusAnddriver));
    var apiURLCreate = environment.apiUrl + '/api/Transport/CreateBusAndDriver';

    return this.http.post<any>(apiURLCreate, BusAnddriver, this.httpOptions)
      .pipe(
        retry(1),
        catchError((err) => this.handleError(err))
      )

  }

  // HttpClient API put() method => Update BusAnddriver
  updateBusAnddriver(id: any, BusAnddriver: any): Observable<any> {
    var apiURLUpdate = environment.apiUrl + '/api/Transport/UpdateBusAndDriver/';

    return this.http.put<any>(apiURLUpdate + id, JSON.stringify(BusAnddriver), this.httpOptions)
      .pipe(
        retry(1),
        catchError((err) => this.handleError(err))
      )
  }

  // HttpClient API delete() method => Delete BusAnddriver
  deleteBusAnddriver(id: any) {
    var apiURLdelete = environment.apiUrl + '/api/Transport/RemoveBusAndDriver/';

    return this.http.delete<any>(apiURLdelete + id, this.httpOptions)
      .pipe(
        retry(1),
        catchError((err) => this.handleError(err))
      )
  }

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

  setFormValue(value: any) {
    this.formvalueSource.next(value);
  }

}
