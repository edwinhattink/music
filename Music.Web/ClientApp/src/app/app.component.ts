import { Component } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  activeLinkIndex = -1;
  navLinks: any[] = [
    {
      label: 'Home',
      link: '/',
      index: 0,
    },
    {
      label: 'Albums',
      link: '/albums',
      index: 0,
    },
    {
      label: 'Artists',
      link: '/artists',
      index: 0,
    },
    {
      label: 'Discs',
      link: '/discs',
      index: 0,
    },
    {
      label: 'Genres',
      link: '/genres',
      index: 0,
    },
    {
      label: 'Tracks',
      link: '/tracks',
      index: 0,
    },
  ];

  constructor(private router: Router) {
  }
}