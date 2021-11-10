import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { Observable, Subject, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TransportService {

  apiURL = environment.apiUrl + '/api/Transport/BusTripDetails/';

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
  getBusTripDetails(): Observable<any> {
    return this.http.get<any>(environment.apiUrl + '/api/Transport/GetBusTripDetails')
      .pipe(
        retry(1),
        catchError((err) => this.handleError(err))
      )
  }

  // HttpClient API get() method => Fetch BusAnddriver
  getBusTripDetail(id: any): Observable<any> {
    return this.http.get<any>(this.apiURL + id)
      .pipe(
        retry(1),
        catchError((err) => this.handleError(err))
      )
  }

  // HttpClient API post() method => Create BusAnddriver
  createBusTripDetail(BusTripDetail: any): Observable<any> {
    // console.log(JSON.stringify(BusAnddriver));
    var apiURLCreate = environment.apiUrl + '/api/Transport/CreateBusTripDetails';

    return this.http.post<any>(apiURLCreate, BusTripDetail, this.httpOptions)
      .pipe(
        retry(1),
        catchError((err) => this.handleError(err))
      )

  }

  // HttpClient API put() method => Update BusAnddriver
  updateBusTripDetails(id: any, BusTripDetail: any): Observable<any> {
    var apiURLUpdate = environment.apiUrl + '/api/Transport/UpdateBusTripDetails/';

    return this.http.put<any>(apiURLUpdate + id, JSON.stringify(BusTripDetail), this.httpOptions)
      .pipe(
        retry(1),
        catchError((err) => this.handleError(err))
      )
  }

  // HttpClient API delete() method => Delete BusAnddriver
  deleteBusTripDetail(id: any) {
    var apiURLdelete = environment.apiUrl + '/api/Transport/RemoveBusTripDetail/';

    return this.http.delete<any>(apiURLdelete + id, this.httpOptions)
      .pipe(
        retry(1),
        catchError((err) => this.handleError(err))
      )
  }

  // HttpClient API put() method => Update BusAnddriver
  UpdateStudentTripDetails(tripId: any, admissionNumber: any): Observable<any> {
    debugger;
    var apiURLUpdate = environment.apiUrl + '/api/Transport/UpdateStudentTripDetails/';

    return this.http.put<any>(apiURLUpdate + tripId , admissionNumber, this.httpOptions)
      .pipe(
        retry(1),
        catchError((err) => this.handleError(err))
      )
  }

  RemoveStudentTripDetails(tripId: any, admissionNumber: any): Observable<any> {
    debugger;
    var apiURLUpdate = environment.apiUrl + '/api/Transport/RemoveStudentTripDetails/';

    return this.http.put<any>(apiURLUpdate + tripId , admissionNumber, this.httpOptions)
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
    debugger;
    this.formvalueSource.next(value);
  }


  
}
