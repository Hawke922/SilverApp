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
    'https://imgur.com/3Cy9L2p.png',
    'https://imgur.com/guRbjN3.png',
    'https://imgur.com/bSelfTL.png',
    'https://imgur.com/ovlki5V.png',
    'https://imgur.com/s7fXZfl.png',
    'https://imgur.com/ozt9xfI.png',
    'https://imgur.com/iUoW3uw.png',
    'https://imgur.com/M98UCzl.png',
    'https://imgur.com/lo7Igj0.png',
    'https://imgur.com/RNFVq4T.png',
    'https://imgur.com/IFc0SF4.png',
    'https://imgur.com/COzLQS2.png'
   ];
   femalePortraits = [
    'https://imgur.com/DkVAodO.png',
    'https://imgur.com/CQygYqi.png',
    'https://imgur.com/K4OxOWa.png',
    'https://imgur.com/gIZEGxA.png',
    'https://imgur.com/qswBfCf.png',
    'https://imgur.com/alLON2o.png',
    'https://imgur.com/8GcaM6Q.png',
    'https://imgur.com/SBMXYie.png',
    'https://imgur.com/x6TFLIa.png',
    'https://imgur.com/YmOvfYe.png'
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
    this.pickedPortrait = 'https://imgur.com/3Cy9L2p.png';
    } else {
    this.pickedPortrait = 'https://imgur.com/DkVAodO.png';
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
