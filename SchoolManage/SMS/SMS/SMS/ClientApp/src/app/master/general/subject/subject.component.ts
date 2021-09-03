import { Component, OnInit } from '@angular/core';
import { Subject } from './Models/subject';
import { SubjectRestApiService } from './subject-rest-api.service';
import { AlertService } from '../../../_services/alert.service';
import { title } from 'process';

@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.css']
})
export class SubjectComponent implements OnInit {

  subjectlist: any;
  addButton : any;

  constructor(private subjectApi : SubjectRestApiService, private alertservice : AlertService) {

   

  }

  

  ngOnInit(): void {

    this.addButton = false;

    this.getData();
  }

  getData()
  {
    this.subjectApi.getSubjects().subscribe(data => {
      this.subjectlist = data;
      this.alertservice.success('Update successful', { keepAfterRouteChange: true });
    });
  }

  addSubject()
  {
    this.subjectlist.push({});
    this.addButton = true;
    
  }

  eventCatch(value:any){

    this.addButton = false;

    if(value===1){
      this.subjectlist.pop();
      return;
    }

    if (value ===2){
      this.addButton = true;
      return;
    }
    
    this.getData();
    //api 

  }
}
