import { Component, OnInit } from '@angular/core';
import { DiscService } from '../services/disc.service';
import { Disc } from '../models/disc';
import { Router } from '@angular/router';

@Component({
  selector: 'app-discs',
  templateUrl: './discs.component.html',
  styleUrls: ['./discs.component.css']
})
export class DiscsComponent implements OnInit {
  public displayedColumns: string[] = ['id', 'number', 'name'];
  public discs: Disc[] = [];

  constructor(
    private discService: DiscService,
    private router: Router
  ) {
    discService.getList().subscribe(discs => this.discs = discs);
  }

  ngOnInit(): void {
  }

  goToDisc(disc: Disc): void {
    this.router.navigate(['discs', disc.id]);
  }

}
