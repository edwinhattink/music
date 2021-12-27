import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Disc } from '../models/disc';
import { DiscService } from '../services/disc.service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-disc',
  templateUrl: './disc.component.html',
  styleUrls: ['./disc.component.css']
})
export class DiscComponent implements OnInit {
  public disc: Disc = <Disc>{};

  constructor(
    private discService: DiscService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (isNaN(params.id) === true) {
        this.disc = <Disc>{};
        return;
      }
      this.discService.getId(params.id).subscribe(disc => {
        this.disc = disc;
      });
    });
  }

  saveDisc(): void {
    if (this.disc.id) {
      this.discService.update(this.disc).subscribe();
    } else {
      this.discService.create(this.disc)
        .subscribe(disc => {
          this.disc = disc;
        });
    }
  }

  deleteDisc(): void {
    if (this.disc.id) {
      this.discService.delete(this.disc).subscribe(() => {
        this.location.back();
      });
    }
  }

}
