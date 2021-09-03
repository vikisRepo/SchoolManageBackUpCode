import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { Observable, Subject, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InventoryService {
  apiURL = environment.apiUrl + '/api/Inventory/';

  private formvalueSource = new Subject<string>();
  formValue$ = this.formvalueSource.asObservable();
  @BlockUI() blockUI: NgBlockUI;

  constructor(private http: HttpClient) { }

  // Http Options
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  // HttpClient API get() method => Fetch Invemtory list
  getInventories(): Observable<any> {
    return this.http.get<any>(this.apiURL + 'Inventory')
      .pipe(
        retry(1),
        catchError((err) => this.handleError(err))
      )
  }

  // HttpClient API get() method => Fetch Inventory
  getInventory(id: any): Observable<any> {
    return this.http.get<any>(this.apiURL + 'Inventory/' + id)
      .pipe(
        retry(1),
        catchError((err) => this.handleError(err))
      )
  }

  // HttpClient API post() method => Create Inventory
  createInventory(Inventory: any): Observable<any> {
    console.log(JSON.stringify(Inventory));
    var apiURLCreate = environment.apiUrl + '/api/Inventory/InsertInventory';

    return this.http.post<any>(apiURLCreate, Inventory, this.httpOptions)
      .pipe(
        retry(1),
        catchError((err) => this.handleError(err))
      )

  }

  // HttpClient API put() method => Update Inventory
  updateInventory(id: any, Inventory: any): Observable<any> {
    var apiURLUpdate = environment.apiUrl + '/api/Inventory/UpdateInventory/';

    return this.http.put<any>(apiURLUpdate + id, JSON.stringify(Inventory), this.httpOptions)
      .pipe(
        retry(1),
        catchError((err) => this.handleError(err))
      )
  }

  // HttpClient API delete() method => Delete Inventory
  deleteInventory(id: any) {

    return this.http.delete<any>(this.apiURL + id, this.httpOptions)
      .pipe(
        retry(1),
        catchError((err) => this.handleError(err))
      )
  }

  setFormValue(value: any) {
    this.formvalueSource.next(value);
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
}
