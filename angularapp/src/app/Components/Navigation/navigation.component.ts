import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  authorized: boolean = false

  ngOnInit(): void {
    if (localStorage.getItem("jwt")) {
      this.authorized = true
    }
  }
}
