import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserToken } from '../token';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent {
  registerStatus : boolean |undefined;
  constructor(private http: HttpClient, private router: Router, private authService: AuthService) {}

  register(form: NgForm) {
    const credentials = {
      'email': form.value.email,
      'password': form.value.password,
      'username': form.value.username,
      'name': form.value.name 
    }
    this.authService.register(credentials);
    this.registerStatus = this.authService.isUserAuthenticated();
    
  }
}
