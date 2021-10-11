import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../../_services';

@Component({
  selector: 'app-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.css']
})
export class SideMenuComponent implements OnInit {

  panelOpenState = false;
  showFiller = false;
  account : any;
  myFeedbackroute : string;
  
  
  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.account = this.accountService.accountValue;
    this.myFeedbackroute = "student-feedback-list/"+this.account.id;
  }

  openSite(siteUrl) : void {
    window.open("//" + siteUrl, '_blank');
  }

}
