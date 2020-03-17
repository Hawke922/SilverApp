import { Component, ViewChild, AfterViewInit, OnInit, OnDestroy } from '@angular/core';
import { NgbCarouselConfig, NgbCarousel } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-character-creation',
  templateUrl: './character-creation.component.html',
  styleUrls: ['./character-creation.component.css'],
  providers: [NgbCarouselConfig]
})
export class CharacterCreationComponent implements AfterViewInit, OnInit, OnDestroy {
  @ViewChild('carousel') carousel: NgbCarousel;
  classes = [
    'warrior',
    'mage',
    'rogue'
   ];
   constructor(config: NgbCarouselConfig) {
    config.showNavigationIndicators = false;
  }

  ngOnInit() {
    document.body.classList.add('bg-gradient');
  }

  ngOnDestroy() {
    document.body.classList.remove('bg-gradient');
  }

  ngAfterViewInit() {
    this.carousel.pause();
  }
}
