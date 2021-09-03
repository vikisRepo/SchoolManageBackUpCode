import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RestService {

  constructor(private http: HttpClient) { }
  
  get (getUrl : string) : Observable<any> {

    // const options = {
    //   responseType: 'text' as const,
    // };

    return this.http.get<any>(getUrl);
  }

  post(postUrl : string, jsonData : any[]) : Observable<any> {

    // const headers =  {
    //   headers: new  HttpHeaders({ 
    //     'Content-Type': 'application/json'})
    // };

    return this.http.post(postUrl,jsonData); //,headers
  }

  delete (deleteUrl : string) : Observable<any> {

    return this.http.delete(deleteUrl);
  }
  
  }
