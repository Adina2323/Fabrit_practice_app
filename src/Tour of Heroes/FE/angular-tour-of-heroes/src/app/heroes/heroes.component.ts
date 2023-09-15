import { Component } from '@angular/core';
import { Hero } from '../hero';
import { HeroService } from '../hero.service';
import { OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map, of } from 'rxjs';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.scss']
})

export class HeroesComponent implements OnInit {
  heroes: Hero[] = [];

  constructor(private heroService: HeroService, private http: HttpClient) { }

  ngOnInit(): void {
    this.getHeroes();
  }

  getHeroes(): void {
    this.heroService.getHeroes()
    .subscribe(heroes => {
      this.heroes = heroes
      
    });
  }

  // heroLink(hero: Hero): string{
  //   var id = hero.id;
  //   console.log(id);
    
  //   this.http
  //     .get(`https://localhost:44380/api/Users/picture-of-hero?id=${id}`)
  //     .pipe(
  //       map((response: any) => {
  //         // Check the response and return true or false based on success or failure
  //         hero.heroPicture = response;
  //       }),
  //       catchError((err: any) => {
  //         console.error('Password Update Failed', err);
  //         return of(false);
  //       })
  //   );
    
  //   return hero.heroPicture + "?auto=format&amp;fit=crop&amp;w=2250&amp;q=80";
  // }

  add(
    name: string, 
    description: string,
    health: number,
    basicDamage: number,
    armour: number,
    heroPicture: string
     ): void {

    name = name.trim();
    description = description.trim();
    if (!name) { return; }
    this.heroService.addHero({ name, description, health, basicDamage, armour,picture: heroPicture } as Hero)
      .subscribe(hero => {
        this.heroes.push(hero);
      });
  }
  delete(hero: Hero): void {
    this.heroes = this.heroes.filter(h => h !== hero);
    this.heroService.deleteHero(hero.id).subscribe();
  }

}