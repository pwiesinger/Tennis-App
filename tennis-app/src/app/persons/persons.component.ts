import { Component, OnInit } from '@angular/core';
import {PersonReplyDto, PersonsService} from '../swagger';



@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.scss']
})
export class PersonsComponent implements OnInit {


  displayedColumns: string[] = ['lastname', 'firstname', 'age'];
  dataSource: PersonReplyDto[] = [];

  constructor(private personsService: PersonsService) { }

  ngOnInit(): void {
    this.personsService.apiPersonsGet().subscribe(x => this.dataSource = x);
  }

}

