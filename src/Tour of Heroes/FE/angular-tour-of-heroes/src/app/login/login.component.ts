import { HttpClient } from '@angular/common/http';
import { Token } from '@angular/compiler';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserToken } from '../token';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  invalidLogin: boolean | undefined;
  
  constructor(private router: Router, private http: HttpClient){}
  
  login(form: NgForm){
    const credentials = {
      'password': form.value.password,
      'email': form.value.email
    }
    this.http.post("https://localhost:44380/api/auth/login",credentials)
    .subscribe((response: any) => {
      const userToken: UserToken = {
        token: response.token,
        email: response.email
      };
      localStorage.setItem("jwt", userToken.token);
      localStorage.setItem("email", userToken.email);
      
      this.invalidLogin = false;
      this.router.navigate(["/dashboard"]); 
    }, err => {
      this.invalidLogin = true;
    })
  }
}
