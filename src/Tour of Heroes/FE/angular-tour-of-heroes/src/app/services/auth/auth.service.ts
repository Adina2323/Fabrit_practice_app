import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserToken } from 'src/app/token';
import { catchError, tap } from 'rxjs/operators';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  validLogin: boolean = false;
  private static readonly key = "jwt_key";
  constructor(private http: HttpClient, private router:Router, private jwtHelper:JwtHelperService) {}

  login(credentials: {
    password: string;
    email: string;
  }) {
    this.http
      .post("https://localhost:44380/api/auth/login", credentials)
      .pipe(
        tap((response: any) => {
          const userToken: UserToken = {
            token: response.token,
            email: response.email
          };
          localStorage.setItem("jwt", userToken.token);
          localStorage.setItem("email", userToken.email);
          this.validLogin = true;
          this.router.navigate(["/dashboard"]);
        }),
        catchError((err: any) => {
          console.error('Login error', err);
          this.validLogin = false;
          // Return an observable with an error to propagate the error further if needed
          return of(err);
        })
      )
      .subscribe();
    }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem("jwt");
    localStorage.removeItem("email");
    this.validLogin = false;
  }

  isUserAuthenticated() : boolean{
    const token = localStorage.getItem("jwt");
    if((token != null)&&(!this.jwtHelper.isTokenExpired(token))){
      return true;
    }
    this.logout();
    return false;
  }

  register(credentials: {
    email: string;
    password: string;
    username: string;
    name: string;
  }) {
    this.http
      .post("https://localhost:44380/api/auth/register", credentials)
      .pipe(
        tap((response: any) => {
          console.log('Registration successful', response);
          const userToken: UserToken = {
            token: response.token,
            email: response.email
          };
          localStorage.setItem("jwt", userToken.token);
          localStorage.setItem("email", userToken.email);
          this.validLogin = true;
          this.router.navigate(["/dashboard"]);
        }),
        catchError((err: any) => {
          console.error('Registration error', err);
          this.validLogin = false;
          // Return an observable with an error to propagate the error further
          return of(err);
        })
      )
      .subscribe();
  }
  getEmailOfCurrentUser()
  {
    return localStorage.getItem("email");
  }
  getAuthorizationToken(){
    return localStorage.getItem("jwt");
  }

}
