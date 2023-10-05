import { HttpClient, HttpHeaders } from "@angular/common/http";
import { AfterViewInit, ContentChildren, Directive, ElementRef, HostListener, Input, Query, QueryList, ViewChild, ViewChildren } from "@angular/core";


@Directive({
  selector: "[inViewAnimation]",
})
export class InViewAnimationDirective implements AfterViewInit {
  @HostListener('window:wheel', ['$event']) // for window scroll events
  onScroll() {
    this.directiveHandler()
  }

  @Input() animationClassName!: string;

  private contact: boolean = false
  private defaults: any = {
    offset: 0,
    interval: 100,
    duration: 350
  };

  constructor(private el: ElementRef) { }

  ngAfterViewInit(): void {
    this.directiveHandler()
    setInterval(() => {
      this.directiveHandler()
    }, 700);
  }

  private directiveHandler(): void {

    let invoke = setInterval(() => {
      const isInView = this.isInViewport()

      if (!isInView || this.contact) return

      if (this.animationClassName) {

        this.el.nativeElement.classList.add(this.animationClassName);
        this.contact = true;
      }
    }, this.defaults.interval);

    setTimeout(() => {
      clearInterval(invoke)
    }, this.defaults.duration);
  }

  private isInViewport(): boolean {
    const bounding = this.el.nativeElement.getBoundingClientRect();

    let top =
      bounding.top -
      (window.innerHeight || document.documentElement.clientHeight);
    let bottom = bounding.top + bounding.height + this.defaults.offset;

    return top < 0 && bottom > 0;
  }
}
