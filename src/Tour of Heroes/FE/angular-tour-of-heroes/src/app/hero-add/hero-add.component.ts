import { Component, isStandalone } from '@angular/core';
import { Hero } from '../hero';
import { Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HeroService } from '../hero.service';
import { CommonModule, Location } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-hero-add',
  standalone : true,
  templateUrl: './hero-add.component.html',
  styleUrls: ['./hero-add.component.css'],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class HeroAddComponent {

  hero?: Hero;

  applyForm = new FormGroup({
    name : new FormControl(''),
    description: new FormControl(''),
    health: new FormControl(''),
    basicDamage: new FormControl(''),
    armour: new FormControl(''),
    heroPicture: new FormControl('')
  })

  constructor(
    private route: ActivatedRoute,
    private heroService: HeroService,
    private location: Location
  ) {}


  goBack(): void {
    this.location.back();
  }

  add():void{
    this.hero = {
      id : 0,
      name : this.applyForm.value.name ?? '', 
      description : this.applyForm.value.description ?? '',
      health : Number(this.applyForm.value.health ?? ''),
      basicDamage : Number(this.applyForm.value.basicDamage ?? ''),
      armour : Number(this.applyForm.value.armour ?? ''),
      heroPicture : this.applyForm.value.heroPicture ?? ''
    }
    this.heroService.addHero(this.hero).subscribe(() => this.goBack());
  };
}

