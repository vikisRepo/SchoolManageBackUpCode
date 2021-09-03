import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-classes',
  templateUrl: './classes.component.html',
  styleUrls: ['./classes.component.css']
})
export class ClassesComponent implements OnInit {
  @Input() title: string = "";
  @Input() route_Link: string = "";

  colors:any = "#5db0f0";
  // /main/lesson-plan/subjectDetails
  constructor(private router: Router) { }

  ngOnInit(): void {
  }
  navigate() {  
   
      this.router.navigate([this.route_Link]);
  }

  getColor(title) { (2)
    switch (title) {
      case 'I':
        return '#E36EEC';
      case 'II':
        return '#6E9BEC';
      case 'III':
        return '#EC846E';
      case 'IV':
        return 'yellow';
      case 'VI':
        return '#FFBD33'; 
      case 'V':
        return '#33FFBD';
      case 'VI':
        return '#33FFBD';
      case 'VII':
        return '#FFBD33';  
      case 'VIII':
        return 'yellow';
      case 'IX':
        return '#EC846E';
      case 'X':
        return '#6E9BEC';
      case 'XI':
        return '#33FFBD';
      case 'XII':
        return '#E36EEC';
      default:
         return 'white';  
    }
  }

}
