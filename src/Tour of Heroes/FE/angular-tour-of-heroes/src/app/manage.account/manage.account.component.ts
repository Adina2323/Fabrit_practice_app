import { Location } from '@angular/common';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { UserService } from '../services/user/user.service';

@Component({
  selector: 'app-manage.account',
  templateUrl: './manage.account.component.html',
  styleUrls: ['./manage.account.component.scss']
})
export class ManageAccountComponent {
  constructor(
    private location:Location, 
    private route: ActivatedRoute,
    private userService: UserService){}

  updateUser: boolean | undefined;
  updatePassword: boolean | undefined;
  errormessage: boolean | undefined;
  

  element = document.querySelector('.login');

  showUserUpdate() {
    this.updateUser = true;
    this.updatePassword = false;
    if(this.element){
      this.element.classList.add('appear');
    }
  }

  showPasswordUpdate(){
    this.updateUser = false;
    this.updatePassword = true;
  }
  goback(){
    this.location.back();
  }

  updateUserPassword(form: NgForm){
    const credentials = {
      password: form.value.password as string,
      rePassword: form.value.rePassword as string,
    };
    this.userService.updateUserPassword(credentials).subscribe((success) => {
      if (success) {
        this.errormessage = false;
      } 
    });
    this.errormessage=true;
    
  }

  updateUserInfo(form:NgForm){
    const credentials = {
      'username' :form.value.username as string,
      'name' : form.value.name as string,
      'email':form.value.email as string
    }
    console.log(credentials);
    this.userService.updateUserInfo(credentials);


  }

}
