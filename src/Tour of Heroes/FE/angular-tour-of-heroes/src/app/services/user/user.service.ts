import { Injectable } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, map, of, tap } from 'rxjs';
import { UpdatePasswordDTO } from 'src/app/UpdatePasswordDTO';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private authService: AuthService, private http: HttpClient) { }

  updateUserPassword(credentials: {
    password: string;
    rePassword: string;
  }): Observable<boolean> {
    if (credentials.password !== credentials.rePassword) {
      return of(false); // Passwords do not match
    }

    const userEmail = this.authService.getEmailOfCurrentUser();

    if (userEmail) {
      const updatePasswordDTO: UpdatePasswordDTO = {
        password: credentials.password,
        email: userEmail,
      };

      return this.http.put('https://localhost:44380/api/Users/update-password', updatePasswordDTO).pipe(
        map((response: any) => {
          // Check the response and return true or false based on success or failure
          const success = response && response.code === 'success';
          return success;
        }),
        catchError((err: any) => {
          console.error('Password Update Failed', err);
          return of(false);
        })
      );
    }

    return of(false);
  }

    updateUserInfo(credentials:{
      username: string,
      name: string,
      email: string
    })
    {
      // Create the request body with both credentials and email
   
      console.log(credentials);
    
      this.http
      .put("https://localhost:44380/api/Users/update-user",(credentials))
      .pipe(
        tap((response: any) => true),
        catchError((err:any) =>{
          console.error('User Update Info Failed.',err);
          return of(err);
        })
      ).subscribe();
    }

    deleteUser()
    {
      
      return this.http.put('https://localhost:44380/api/Users/delete-user', this.authService.getEmailOfCurrentUser()).pipe(
        map((response: any) => {
          // Check the response and return true or false based on success or failure
          const success = response && response.code === 'success';
          this.authService.logout();
          return success;
        }),
        catchError((err: any) => {
          console.error('Delete User Failed', err);
          return of(false);
        })
      );
    }
  }

