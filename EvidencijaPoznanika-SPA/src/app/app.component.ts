import { AlertifyService } from './services/alertify.service';
import { ApiPersonsService } from './services/api-persons.service';
import { Component, OnInit } from '@angular/core';
import { Osoba } from 'src/models/osoba';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  showPersons: boolean = true;
  srednjaStarost = 0;
  maxVisina = 0;
  osobe: Osoba[] = [];
  osoba: Osoba = null;

  constructor(private apiService: ApiPersonsService,
              private alertifyService: AlertifyService) {}

  ngOnInit(){
    this.showAll();
  }

  showAll() {
    this.osoba = null;
    this.showPersons = true;
    this.apiService.getMaxVisina().subscribe(
      (res) => {
        this.maxVisina = res;
        this.alertifyService.success('Учитани су сви корисници.');
      },
      (err) =>{
        this.alertifyService.error(err);
      }
    );
    this.apiService.getSrednjaStarost().subscribe(
      (res) => {
        this.srednjaStarost = res;
      },
      (err) =>{
        this.alertifyService.error(err);
      }
    );
    this.apiService.getOsobe().subscribe(
      (res) => {
        this.osobe = res;
      },
      (err) =>{
        this.alertifyService.error(err);
      }
    )
    console.log(this.srednjaStarost);
  }

  showSmederevci() {
    this.osoba = null;
    this.showPersons = true;
    this.apiService.getSmederevci().subscribe(
      (res) => {
        this.osobe = res;
      },
      (err) =>{
        this.alertifyService.error(err);
      }
    )
  }

  showPunoletni() {
    this.osoba = null;
    this.showPersons = true;
    this.apiService.getPunoletni().subscribe(
      (res) => {
        this.osobe = res;
      },
      (err) =>{
        this.alertifyService.error(err);
      }
    )
  }

  removePerson(id: number){
    this.osoba = null;
    this.osobe = this.osobe.filter(o => o.id !== id);
    this.apiService.deleteOsoba(id);
    this.alertifyService.success('Особа је уклоњена');
  }

  updatePerson(id) {
    this.showPersons = false;
    this.osoba = this.osobe.filter(o => o.id === id).pop();
  }

  addPerson() {
    this.showPersons = false;
    this.osoba = null;
  }
}
