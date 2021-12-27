import { Component, OnInit } from '@angular/core';
import { DiscService } from '../services/disc.service';
import { Disc } from '../models/disc';

@Component({
  selector: 'app-discs',
  templateUrl: './discs.component.html',
  styleUrls: ['./discs.component.css']
})
export class DiscsComponent implements OnInit {
  public discs: Disc[] = [];

  constructor(private discService: DiscService) {
    discService.getList().subscribe(discs => this.discs = discs);
  }

  ngOnInit(): void {
  }

}
