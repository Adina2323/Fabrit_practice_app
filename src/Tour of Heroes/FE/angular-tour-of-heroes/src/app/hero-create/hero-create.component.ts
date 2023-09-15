import { Component, OnInit } from '@angular/core';
import { Hero } from '../hero';
import { HeroService } from '../hero.service';
import { Location } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-hero-create',
  templateUrl: './hero-create.component.html',
  styleUrls: ['./hero-create.component.scss']
})
export class HeroCreateComponent{
  hero?: Hero;
  selectedPower: string[] = [];
  powers: string[] = [
    "Telepathy",
    "Mediumship",
    "AstralProjection",
    "EnergyMedicine",
    "Hydrokinesis",
    "Levitation",
    "Materialization",
    "Pyrokinesis",
    "Telekinesis",
    "Clairvoyance",
    "Magic",
    "SuperhumanStrength",
    "TimeTravel",
    "WitchCraft",
    "Shapeshifting",
    "Invisibility",
    "Imortality"
  ];

  applyForm = new FormGroup({
    name: new FormControl(''),
    description: new FormControl(''),
    health: new FormControl(0),
    basicDamage: new FormControl(0),
    armour: new FormControl(0),
    picture: new FormControl(''),
    powers: new FormControl<string[]>([])
  })

  constructor(
    private heroService: HeroService,
    private location: Location,
  ) { }



  goBack(): void {
    this.location.back();
  }

  add(): void {
    const selected: string[] = this.applyForm.value.powers || [];
    this.hero = {
      id: 0,
      name: this.applyForm.value.name ?? '',
      description: this.applyForm.value.description ?? '',
      health: Number(this.applyForm.value.health ?? ''),
      basicDamage: Number(this.applyForm.value.basicDamage ?? ''),
      armour: Number(this.applyForm.value.armour ?? ''),
      powers: selected,
      picture: this.applyForm.value.picture ?? ''
    }
    console.log(this.hero)
    this.heroService.addHero(this.hero).subscribe(() => this.goBack());
  };


  updateSelectedPowers(power: string, isChecked: boolean): void {
    const powersControl = this.applyForm.get('powers');
    const currentPowers = powersControl?.value || [];
  
    if (isChecked) {
      currentPowers.push(power);
    } else {
      const index = currentPowers.indexOf(power);
      if (index >= 0) {
        currentPowers.splice(index, 1);
      }
    }
  
    powersControl?.setValue(currentPowers);
  }
}
