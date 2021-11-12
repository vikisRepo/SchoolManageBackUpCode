import { Component, OnInit } from '@angular/core';
import { Role } from 'src/app/_models';
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
  mystuFeedbackroute : string;
  mystaffFeedbackroute : string;
  myeLetterroute : string;
  role : Role;
  
  
  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.account = this.accountService.accountValue;
    debugger;
    this.mystuFeedbackroute = "student-feedback-list/"+this.account.id;
    this.mystaffFeedbackroute = "staff-feedback-list/"+this.account.id;
    this.myeLetterroute = "e-letter-list/" + this.account.id;
    // this.role = this.account.Role;
  }

  openSite(siteUrl) : void {
    window.open("//" + siteUrl, '_blank');
  }

}
