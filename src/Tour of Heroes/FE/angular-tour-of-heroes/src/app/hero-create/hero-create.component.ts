import { Component } from '@angular/core';
import { Hero } from '../hero';
import { HeroService } from '../hero.service';
import { Location } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-hero-create',
  templateUrl: './hero-create.component.html',
  styleUrls: ['./hero-create.component.css']
})
export class HeroCreateComponent {
  hero?: Hero;

  applyForm = new FormGroup({
    name: new FormControl(''),
    description: new FormControl(''),
    health: new FormControl(0),
    basicDamage: new FormControl(0),
    armour: new FormControl(0),
    heroPicture: new FormControl('')
  })

  constructor(
    private heroService: HeroService,
    private location: Location,
  ) { }


  goBack(): void {
    this.location.back();
  }

  add(): void {
    this.hero = {
      id: 0,
      name: this.applyForm.value.name ?? '',
      description: this.applyForm.value.description ?? '',
      health: Number(this.applyForm.value.health ?? ''),
      basicDamage: Number(this.applyForm.value.basicDamage ?? ''),
      armour: Number(this.applyForm.value.armour ?? ''),
      heroPicture: this.applyForm.value.heroPicture ?? ''
    }
    this.heroService.addHero(this.hero).subscribe(() => this.goBack());
  };
}
