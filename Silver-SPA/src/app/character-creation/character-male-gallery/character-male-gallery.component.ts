import { Component, ViewChild, AfterViewInit, EventEmitter, OnChanges, Output, SimpleChanges } from '@angular/core';
import { NgbCarouselConfig, NgbCarousel } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-character-male-gallery',
  templateUrl: './character-male-gallery.component.html',
  styleUrls: ['./character-male-gallery.component.css'],
  providers: [NgbCarouselConfig]
})
export class CharacterMaleGalleryComponent implements AfterViewInit, OnChanges {
  @ViewChild('carousel') carousel: NgbCarousel;

  images = [
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

  constructor(config: NgbCarouselConfig) {
    config.showNavigationIndicators = false;
  }

  print(currentImage) {
    const pickedIndex = currentImage.getAttribute('image-index');
    console.log('Image Id: ', pickedIndex);
  }

  ngAfterViewInit() {
  }

  ngOnChanges(changes: SimpleChanges) {
    console.log(changes);
  }
}
