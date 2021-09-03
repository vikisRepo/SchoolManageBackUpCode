import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-master',
  templateUrl: './master.component.html',
  styleUrls: ['./master.component.css']
})
export class MasterComponent implements OnInit {
  mHeight = '500px';
  constructor() { }

  ngOnInit(): void {
    this.mHeight = `${window.innerHeight - 70}px`;
  }

}
