/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { MarvelCardComponent } from './marvel-card.component';

let component: MarvelCardComponent;
let fixture: ComponentFixture<MarvelCardComponent>;

describe('MarvelCard component', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [MarvelCardComponent],
      imports: [BrowserModule],
      providers: [
        { provide: ComponentFixtureAutoDetect, useValue: true }
      ]
    });
    fixture = TestBed.createComponent(MarvelCardComponent);
    component = fixture.componentInstance;
  }));

  it('should do something', async(() => {
    expect(true).toEqual(true);
  }));
});
