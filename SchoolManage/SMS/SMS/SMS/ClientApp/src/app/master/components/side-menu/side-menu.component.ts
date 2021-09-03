import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.css']
})
export class SideMenuComponent implements OnInit {

  panelOpenState = false;
  showFiller = false;
  
  constructor() { }

  ngOnInit(): void {
  }

  openSite(siteUrl) : void {
    window.open("//" + siteUrl, '_blank');
  }

}
