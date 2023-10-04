import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { HomeService } from '../../Services/home.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  auth2: any;
  @ViewChild('loginRef', { static: false }) loginElement!: ElementRef;
  googleAuthFailAlert: boolean = false;

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
  scrollLock: boolean = false;

  loginFormOpened: boolean = false;
  registrationFormOpened: boolean = false;

  registrationForm = new FormGroup({
    userName: new FormControl<string>(''),
    email: new FormControl<string>(''),
    password: new FormControl<string>(''),
  });

  loginForm = new FormGroup({
    email: new FormControl<string>(''),
    password: new FormControl<string>(''),
  });

  constructor(private homeService: HomeService, private router: Router) {

  }

  ngAfterViewInit() {
    this.scrollTargets = {
      0: this.target,
      1: this.scope,
      2: this.about,
      3: this.bottom
    };
  }

  callLogin() {
    console.log(this.loginElement)

    this.auth2.attachClickHandler(this.loginElement.nativeElement, {},
      (googleAuthUser: any) => {

        let profile = googleAuthUser.getBasicProfile();
        // console.log('Token || ' + googleAuthUser.getAuthResponse().id_token);
        // console.log('ID: ' + profile.getId());
        // console.log('Name: ' + profile.getName());
        // console.log('Image URL: ' + profile.getImageUrl());
        // console.log('Email: ' + profile.getEmail());

        const authParams = {
          email: profile.getEmail(),
          userName: profile.getName(),
          imageUrl: profile.getImageUrl()
        }

        this.homeService.sendGoogleAuthInfo(authParams).subscribe(jwt => {
          localStorage.setItem("jwt", jwt)
        },
          error => {
            console.error("Google auth failed", error)
          })

      }, (error: any) => {
        this.googleAuthFailAlert = true;
        console.error(error);
      });

  }

  googleAuthSDK() {

    (<any>window)['googleSDKLoaded'] = () => {
      (<any>window)['gapi'].load('auth2', () => {
        this.auth2 = (<any>window)['gapi'].auth2.init({
          client_id: '211767464764-fv5l0e8pqe5kvn5us9jb41ktgm2074i4.apps.googleusercontent.com',
          plugin_name: 'login',
          cookiepolicy: 'single_host_origin',
          scope: 'profile email'
        });
        this.callLogin();
      });
    }

    (function (d, s, id) {
      var js, fjs = d.getElementsByTagName(s)[0];
      if (d.getElementById(id)) { return; }
      js = d.createElement('script');
      js.id = id;
      js.src = "https://apis.google.com/js/platform.js?onload=googleSDKLoaded";
      fjs?.parentNode?.insertBefore(js, fjs);
    }(document, 'script', 'google-jssdk'));
  }

  @HostListener('window:wheel', ['$event']) onScrollEvent(event) {
    if (this.scrollLock || this.scrollAnimation) {
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

  sendRegistrationForm() {
    this.homeService.sendRegistrationForm(this.registrationForm).subscribe(jwt => {
      localStorage.setItem("jwt", jwt)
      this.router.navigate(['/general']);
    },
      error => {
        console.error("Registration failed", error)
    })
  }

  sendLoginForm() {
    this.homeService.sendLoginForm(this.loginForm).subscribe(jwt => {
      localStorage.setItem("jwt", jwt)
    },
      error => {
        console.error("Login failed", error)
      })
  }

  openLoginForm(): void {
    this.registrationFormOpened = false;
    this.loginFormOpened = true;
    this.scrollLock = true;
    this.googleAuthSDK();
  }

  closeLoginForm(): void {
    this.loginFormOpened = false;
    this.scrollLock = false;
  }

  openRegistrationForm(): void {
    this.loginFormOpened = false;
    this.registrationFormOpened = true;
    this.scrollLock = true;
    this.googleAuthSDK();
  }

  closeRegistrationForm(): void {
    this.registrationFormOpened = false;
    this.scrollLock = false;
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
