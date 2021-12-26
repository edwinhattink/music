import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { DiscComponent } from './disc.component';

describe('DiscComponent', () => {
  let component: DiscComponent;
  let fixture: ComponentFixture<DiscComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ DiscComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DiscComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
