import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';


@Component({
  selector: 'app-academic-detail',
  templateUrl: './academic-detail.component.html',
  styleUrls: ['./academic-detail.component.css']
})
export class AcademicDetailComponent implements OnInit {

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;
  
  //Class & Sections Subjects Lesson Plan Timetable
  columnsToDisplay = ['classSections', 'subjects',
    'lessonPlan', 'timeTable'];

  academicDetails = [{
    
    classSections: '1-A', subjects: 'Maths, Science'
  }, {
    classSections: '2-B', subjects: 'Maths, Science'
  },
  {
    classSections: '3-A', subjects: 'Maths, Science'
  }, 
  {
    classSections: '10-A', subjects: 'Maths, Science'
  }
];


  constructor() { }

  ngOnInit(): void {
    this.loadacademic();
  }

  loadacademic() {


  }



}
