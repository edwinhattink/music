import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
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
      index: 1,
    },
    {
      label: 'Artists',
      link: '/artists',
      index: 2,
    },
    {
      label: 'Discs',
      link: '/discs',
      index: 3,
    },
    {
      label: 'Genres',
      link: '/genres',
      index: 4,
    },
    {
      label: 'Tracks',
      link: '/tracks',
      index: 5,
    },
  ];

  constructor(private router: Router) {
  }

  public ngOnInit(): void {
    this.router.events.subscribe((res) => {
      this.activeLinkIndex = this.navLinks.indexOf(this.navLinks.find(tab => tab.link === this.router.url));
    });
  }
}
