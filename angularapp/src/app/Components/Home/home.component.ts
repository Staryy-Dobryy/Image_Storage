import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, HostListener, ViewChild } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  @ViewChild("top", { static: false })
  target!: ElementRef | undefined;
  @ViewChild("scope", { static: false })
  scope!: ElementRef | undefined;
  @ViewChild("about", { static: false })
  about!: ElementRef | undefined;
  @ViewChild("bottom", { static: false })
  bottom!: ElementRef | undefined;

  currentScrollTarget: number = 0;
  scrollTargets: { [id: number]: ElementRef | undefined };

  scrollAnimationTimer!: any;
  scrollAnimation: boolean = false;

  constructor(http: HttpClient) {

  }
  ngAfterViewInit() {
    this.scrollTargets = {
      0: this.target,
      1: this.scope,
      2: this.about,
      3: this.bottom
    };
  }
  @HostListener('window:wheel', ['$event']) onScrollEvent(event) {
    console.log(this.scrollAnimation)

    if (this.scrollAnimation == true) {
      return;
    }

    if (event['deltaY'] > 0 && this.currentScrollTarget + 1 <= 3) {
      this.currentScrollTarget++;
      this.scrollToElement(this.scrollTargets[this.currentScrollTarget]);
    }
    else if (event['deltaY'] < 0 && this.currentScrollTarget - 1 >= 0) {
      this.currentScrollTarget--;
      this.scrollToElement(this.scrollTargets[this.currentScrollTarget]);
    }
  } 


  scrollToElement(element: any): void {

    if (element instanceof ElementRef) {
      this.startAnimation();
      element.nativeElement.scrollIntoView({ behavior: "smooth", block: "start", inline: "nearest" });
    }
    else if (element as string) {
      console.log(this.scrollTargets[2])
      switch (element) {
        case "about":
          this.startAnimation();
          this.currentScrollTarget = 2
          this.scrollTargets[2]!.nativeElement.scrollIntoView({ behavior: "smooth", block: "start", inline: "nearest" });
          break;
        case "scope":
          this.startAnimation();
          this.currentScrollTarget = 1
          this.scrollTargets[1]!.nativeElement.scrollIntoView({ behavior: "smooth", block: "start", inline: "nearest" });
          break;
      }
    }
  }

  private startAnimation(): void {
    this.scrollAnimation = true
    this.scrollAnimationTimer = setTimeout(() => {
      if (this.scrollAnimation == true) {
        this.scrollAnimation = false;
      }
    }, 350);
  }
}
