import { HttpClient } from '@angular/common/http';
import { Token } from '@angular/compiler';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserToken } from '../token';
import { AuthService } from '../services/auth/auth.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  constructor(private authService: AuthService){}
  loginStatus : boolean |undefined;

  
  login(form:NgForm){
    const credentials = {
      'password': form.value.password,
      'email': form.value.email
    }
    this.authService.login(credentials);
    this.loginStatus = this.authService.isUserAuthenticated();
  }

}
