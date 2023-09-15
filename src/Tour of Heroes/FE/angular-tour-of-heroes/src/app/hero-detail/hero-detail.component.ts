import { Component, Input } from '@angular/core';
import { Hero } from '../hero';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { HeroService } from '../hero.service';
import { HttpBackend, HttpClient } from '@angular/common/http';
import { AuthService } from '../services/auth/auth.service';
import { catchError, map, of } from 'rxjs';

@Component({
  selector: 'app-hero-detail',
  templateUrl: './hero-detail.component.html',
  styleUrls: ['./hero-detail.component.scss']
})
export class HeroDetailComponent {
  @Input() hero?: Hero;

  constructor(
    private route: ActivatedRoute,
    private heroService: HeroService,
    private location: Location,
    private http:HttpClient,
    private auth:AuthService
  ) {}

  ngOnInit(): void {
    this.getHero();
  }
  
  getHero(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.heroService.getHero(id)
      .subscribe(hero => this.hero = hero);
  }
  
  goBack(): void {
    this.location.back();
  }

  save(): void {
    if (this.hero) {
      this.heroService.updateHero(this.hero).subscribe(() => this.goBack());
    }
  }

  chooseHero():void{
    console.log('lllllllllllll');
    
    const credentials = {
      email: this.auth.getEmailOfCurrentUser(),
      heroId: this.hero?.id
    }

    this.http.put(`https://localhost:44380/api/Users/choose-hero`, credentials)
    .pipe(
           map((response: any) => {
             console.log(response);
              
           }),
            catchError((err: any) => {
               console.error('dasdsad', err);
             return of(false);
            })).subscribe();
  }

  delete():void{
    const id = Number(this.route.snapshot.paramMap.get('id'));
        this.heroService.deleteHero(id).subscribe(() => this.goBack());
    }
  

  
}