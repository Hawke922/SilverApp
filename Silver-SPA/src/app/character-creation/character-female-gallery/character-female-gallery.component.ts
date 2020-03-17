import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { NgbCarouselConfig, NgbCarousel } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-character-female-gallery',
  templateUrl: './character-female-gallery.component.html',
  styleUrls: ['./character-female-gallery.component.css'],
  providers: [NgbCarouselConfig]
})
export class CharacterFemaleGalleryComponent implements AfterViewInit {
  @ViewChild('carousel') carousel: NgbCarousel;

  images = [
      'https://imgur.com/DkVAodO.png',
      'https://imgur.com/CQygYqi.png',
      'https://imgur.com/amhOEmN.png',
      'https://imgur.com/K4OxOWa.png',
      'https://imgur.com/gIZEGxA.png',
      'https://imgur.com/qswBfCf.png',
      'https://imgur.com/alLON2o.png',
      'https://imgur.com/8GcaM6Q.png',
      'https://imgur.com/SBMXYie.png',
      'https://imgur.com/x6TFLIa.png',
      'https://imgur.com/YmOvfYe.png'
    ];
    constructor(config: NgbCarouselConfig) {
      config.showNavigationIndicators = false;
    }

    ngAfterViewInit() {
      this.carousel.pause();
    }
  }