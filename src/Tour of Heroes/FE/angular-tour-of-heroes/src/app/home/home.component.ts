import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HeroService } from '../hero.service';
import { heroDisplay } from '../heroDisplay';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent {
  @Input() hero?: heroDisplay;
  @Input() email?: string;
  loggedIn? : boolean;

  constructor(
    private heroService: HeroService,
    private auth: AuthService
  ) {}


 ngOnInit(){
  this.getHero();

 }
  getHero(): void {
    this.email = this.auth.getEmailOfCurrentUser() as string;
    this.heroService.getHeroOfUser(this.email)
    .subscribe(hero => this.hero = hero || { name: null, picture: null });
    this.loggedIn = false;
    if (this.email != null)
    {
      this.loggedIn = true;
    }

  }

  
}
