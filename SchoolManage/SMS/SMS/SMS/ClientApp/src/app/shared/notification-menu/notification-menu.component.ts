import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-notification-menu',
  templateUrl: './notification-menu.component.html',
  styleUrls: ['./notification-menu.component.css']
})
export class NotificationMenuComponent implements OnInit {

  showNotification: boolean;
  constructor() { }

  ngOnInit(): void {
  }

  openNotification(state: boolean) {
    console.log(state);

    this.showNotification = state;
  }


}
