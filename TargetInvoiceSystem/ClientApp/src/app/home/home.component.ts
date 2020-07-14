import { Component, OnInit, AfterViewInit, ElementRef } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, AfterViewInit {

  constructor(private element:ElementRef) { }
  ngAfterViewInit(): void {
    this.element.nativeElement.ownerDocument.body.style.backgroundColor='#fff';
  }

  ngOnInit(): void {
  }

}
