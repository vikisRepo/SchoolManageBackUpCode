import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { forkJoin, Observable, throwError } from 'rxjs';
import { catchError, delay, retry } from 'rxjs/operators';
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
      banks: this.getfactorydata('/api/Factory/Bank', 1000),
      cities: this.getfactorydata('/api/Factory/City', 2000),
      departments: this.getfactorydata('/api/Factory/Departments', 3000),
      designation: this.getfactorydata('/api/Factory/Designations', 3000),
      employeestatus: this.getfactorydata('/api/Factory/EmployeeStatus', 2000),
      bloodgroup: this.getfactorydata('/api/Factory/Bloodgroup', 2000),
      maritalStatus: this.getfactorydata('/api/Factory/MaritalStatus', 2000),
      religion: this.getfactorydata('/api/Factory/Religions', 2000),
      nationalities: this.getfactorydata('/api/Factory/Nationalities', 2000),
      gender: this.getfactorydata('/api/Factory/Gender', 2000),
      salutations: this.getfactorydata('/api/Factory/Salutation', 2000),
      language: this.getfactorydata('/api/Factory/Language', 2000),
      staffType: this.getfactorydata('/api/Factory/StaffType', 2000)
      
      // requestThree: this.getfactorydata('/api​/Factory​/RepotingTo')
    })
    .subscribe(({banks, cities,departments,employeestatus,bloodgroup,maritalStatus,religion,gender,salutations,language,staffType,nationalities,designation}) => {
      SmsConstant.bank = banks;
      SmsConstant.city = cities;
      SmsConstant.department = departments;
      SmsConstant.employmentStatus = employeestatus;
      SmsConstant.bloods = bloodgroup;
      SmsConstant.maritalStatus = maritalStatus;
      SmsConstant.religion = religion;
      SmsConstant.gender = gender;
      SmsConstant.salutations = salutations;
      SmsConstant.languageKnown = language;
      SmsConstant.firstLanguage = language;
      SmsConstant.secondLanguage = language;
      SmsConstant.motherTongue = language;
      SmsConstant.staffType = staffType;
      SmsConstant.nationality = nationalities;
      SmsConstant.designation = designation;
    });

   }


   getfactorydata(apiURL : any, delayDuration : any): Observable<any> {
    apiURL = environment.apiUrl + apiURL;
    return this.http.get<any>(apiURL)
    .pipe(
      delay(delayDuration),
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
