import { Component, OnInit } from '@angular/core';
import { Hero } from '../hero';
import { HeroService } from '../hero.service';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: [ './dashboard.component.css' ]
})
export class DashboardComponent implements OnInit {
  heroes: Hero[] = [];

  constructor(private heroService: HeroService, private router: Router, private jwtHelper: JwtHelperService) { }

  ngOnInit(): void {
    this.getHeroes();
  }

  getHeroes(): void {
    this.heroService.getHeroes()
      .subscribe(heroes => this.heroes = heroes.slice(1, 5));
  }

  isUserAuthenticated(){
    const token = localStorage.getItem("jwt");
    if((token != null)&&(!this.jwtHelper.isTokenExpired(token))){
      return true;
    }
    return false;
  }

  logOut(){
    localStorage.removeItem("jwt");
    localStorage.removeItem("email");
  }
}