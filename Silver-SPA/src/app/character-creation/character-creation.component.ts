import { Component, ViewChild, AfterViewInit, OnInit, OnDestroy } from '@angular/core';
import { NgbCarouselConfig, NgbCarousel } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import { UserService } from '../_services/user.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-character-creation',
  templateUrl: './character-creation.component.html',
  styleUrls: ['./character-creation.component.css'],
  providers: [NgbCarouselConfig]
})
export class CharacterCreationComponent implements AfterViewInit, OnInit, OnDestroy {
  @ViewChild('carouselClass') carouselClass: NgbCarousel;
  @ViewChild('carouselGender') carouselGender: NgbCarousel;
  @ViewChild('carouselPortraitsMale') carouselPortraitsMale: NgbCarousel;
  @ViewChild('carouselPortraitsFemale') carouselPortraitsFemale: NgbCarousel;

  model: any = {};
  malePicked = true;
  error;
  pickedClass;
  pickedPortrait;
  malePortraits = [
    'assets/portraits/male1.png',
    'assets/portraits/male2.png',
    'assets/portraits/male3.png',
    'assets/portraits/male4.png',
    'assets/portraits/male5.png',
    'assets/portraits/male6.png',
    'assets/portraits/male7.png',
    'assets/portraits/male8.png',
    'assets/portraits/male9.png',
    'assets/portraits/male10.png',
    'assets/portraits/male11.png',
    'assets/portraits/male12.png'
   ];
   femalePortraits = [
    'assets/portraits/female1.png',
    'assets/portraits/female2.png',
    'assets/portraits/female3.png',
    'assets/portraits/female4.png',
    'assets/portraits/female5.png',
    'assets/portraits/female6.png',
    'assets/portraits/female7.png',
    'assets/portraits/female8.png',
    'assets/portraits/female9.png',
    'assets/portraits/female10.png'
  ];

  constructor(config: NgbCarouselConfig, private router: Router, private userService: UserService, private authService: AuthService) {
    config.showNavigationIndicators = false;
    config.showNavigationArrows = false;
  }

  ngOnInit() {
    document.body.classList.add('bg-gradient');
  }

  ngOnDestroy() {
    document.body.classList.remove('bg-gradient');
  }

  ngAfterViewInit() {
    this.carouselGender.pause();
    this.carouselClass.pause();
  }

  genderSwitchNext() {
    this.carouselGender.next();
    if (this.carouselGender.activeId === 'ngb-slide-0') {
    this.malePicked = true;
    } else {
    this.malePicked = false;
    }
  }

  genderSwitchPrevious() {
    this.carouselGender.prev();
    if (this.carouselGender.activeId === 'ngb-slide-0') {
    this.malePicked = true;
    } else {
    this.malePicked = false;
    }
  }

  classSwitchNext() {
    this.carouselClass.next();
  }

  classSwitchPrevious() {
    this.carouselClass.prev();
  }

  malePortraitSwitchNext() {
    this.carouselPortraitsMale.next();
    this.carouselPortraitsMale.pause();
  }

  malePortraitSwitchPrevious() {
    this.carouselPortraitsMale.prev();
    this.carouselPortraitsMale.pause();
  }

  femalePortraitSwitchNext() {
    this.carouselPortraitsFemale.next();
    this.carouselPortraitsFemale.pause();
  }

  femalePortraitSwitchPrevious() {
    this.carouselPortraitsFemale.prev();
    this.carouselPortraitsFemale.pause();
  }

// this.pickedPortrait = id.getAttribute('portrait-index');

  createCharacter() {
    const pickedName = this.model.name;
    if (this.carouselClass.activeId === 'ngb-slide-2') {
      this.pickedClass = 'warrior';
    } else if (this.carouselClass.activeId === 'ngb-slide-3') {
      this.pickedClass = 'rogue';
    } else {
      this.pickedClass = 'mage';
    }
    if (this.malePicked) {
    this.pickedPortrait = 'assets/portraits/male1.png';
    } else {
    this.pickedPortrait = 'assets/portraits/female1.png';
    }
    this.model = {
    name: pickedName,
    class: this.pickedClass,
    pictureUrl: this.pickedPortrait,
    userId: this.authService.decodedToken.nameid
    };
    this.userService.createCharacter(this.model).subscribe(() => {
      this.router.navigate(['/charselect']);
    }, error => {
      this.error = error;
      console.log(error);
    });
  }
}
