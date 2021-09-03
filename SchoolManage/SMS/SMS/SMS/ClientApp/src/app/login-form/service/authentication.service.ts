import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { LoginUser } from '../login-user';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private userSubject: BehaviorSubject<LoginUser> | undefined;
  public user: Observable<LoginUser> | undefined;
  _loginuser : LoginUser = new LoginUser();

  headers : HttpHeaders;

  constructor(private http: HttpClient) { 
    this.headers = new HttpHeaders({'Content-Type':'application/json; charset=utf-8'});

    this.userSubject = new BehaviorSubject<LoginUser>(JSON.parse(localStorage.getItem('user') || '{}'));
    
    this.user = this.userSubject.asObservable();
  }

  public get userValue(): LoginUser {
    this._loginuser = this.userSubject.value;
    return this._loginuser;
  }

  getAuth(loginJson : string){
    console.log(loginJson);
    return this.http.post<LoginUser>('api/Auth/UserAuth', loginJson, {headers: this.headers})
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('user', JSON.stringify(user));
                this?.userSubject?.next(user);
                return user;
            }));
  }
}
