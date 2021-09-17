import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { forkJoin, Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { SmsConstant } from 'src/app/shared/constant-values';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FactorydataService {

  constructor(private http: HttpClient) {
    
   }

   Loadfactorydata()
   {
    forkJoin({
      banks: this.getfactorydata('/api/Factory/Bank'),
      // requestTwo: this.getfactorydata('/api/Factory/schoolName'),
      // requestThree: this.getfactorydata('/api​/Factory​/RepotingTo')
    })
    .subscribe(({banks}) => {
      SmsConstant.bank = banks;
    });
   }


   getfactorydata(apiURL : any): Observable<any> {
    apiURL = environment.apiUrl + apiURL;
    return this.http.get<any>(apiURL)
    .pipe(
      retry(1),
      catchError((err)=>this.handleError(err))
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
