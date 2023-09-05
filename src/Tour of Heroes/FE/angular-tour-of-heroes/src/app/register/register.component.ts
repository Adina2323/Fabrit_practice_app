import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserToken } from '../token';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent {
  invalidRegistration : boolean | undefined;
  constructor(private http: HttpClient, private router: Router) {}

  register(form: NgForm) {
    const credentials = {
      'email': form.value.email,
      'password': form.value.password,
      'username': form.value.username,
      'name': form.value.name 
    }
    this.http.post("https://localhost:44380/api/auth/register",credentials)
    .subscribe(
      (response: any) => {
        console.log('Registration successful', response);
        const userToken: UserToken = {
          token: response.token,
          email: response.email
        };
        localStorage.setItem("jwt", userToken.token);
        localStorage.setItem("email", userToken.email);
        this.invalidRegistration = false;
        this.router.navigate(["/dashboard"]); // Redirect to the desired route after successful login
      }, 
      (error) => {
        console.error('Registration error', error);
        this.invalidRegistration = true;
      }
    );
  }
}
