import { ApiPersonsService } from './../services/api-persons.service';
import { AlertifyService } from './../services/alertify.service';
import { Component, OnInit, Input } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Osoba } from 'src/models/osoba';

@Component({
  selector: 'app-osoba-form',
  templateUrl: './osoba-form.component.html',
  styleUrls: ['./osoba-form.component.css']
})
export class OsobaFormComponent implements OnInit {
  public osobaForm: FormGroup;
  
  @Input() osoba: Osoba;

  constructor(private formBuilder: FormBuilder, 
              private alertifyService: AlertifyService,
              private apiService: ApiPersonsService) {
    this.osobaForm = this.formBuilder.group({
      maticniBroj: ['', Validators.required],
      ime: ['', Validators.required],
      prezime: ['', Validators.required],
      visina: [null],
      tezina: [null],
      bojaOciju: [null],
      telefon: [null,Validators.pattern('((\\+381)|(0))6[0-9]\\.[0-9][0-9][0-9]\\.[0-9][0-9][0-9][0-9]')],
      email: ['', [Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$'), Validators.required]],
      rodjendan: [new Date()],
      adresa: [null],
      prebivaliste: ['Beograd']
    });
    
  }
  ngOnInit() {
    console.log('PONOVO');
    if(this.osoba !== null) {
      this.osobaForm = this.formBuilder.group({
        maticniBroj: [this.osoba.maticniBroj, Validators.required],
        ime: [this.osoba.ime, Validators.required],
        prezime: [this.osoba.prezime, Validators.required],
        visina: [this.osoba.visina],
        tezina: [this.osoba.tezina],
        bojaOciju: [this.osoba.bojaOciju],
        telefon: [this.osoba.telefon,Validators.pattern('((\\+381)|(0))6[0-9]\\.[0-9][0-9][0-9]\\.[0-9][0-9][0-9][0-9]')],
        email: [this.osoba.email, [Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$'), Validators.required]],
        rodjendan: [this.osoba.rodjendan],
        adresa: [this.osoba.adresa],
        prebivaliste: [this.osoba.prebivaliste]
      });
    }
  }

  sendFormValues(): void {
    if (this.osobaForm.valid) {
      this.apiService.insertOsoba(this.osobaForm.value).subscribe(
        (res) =>{ this.alertifyService.success('Особа је успешно додата!');},
        (err) => {this.alertifyService.error(err);
          console.log(err);
        }
      );
    } else {
      this.alertifyService.error('Дошло је до грешке');
    }
  }

  sendUpdateValues(): void {
    this.osobaForm.value['id'] = this.osoba.id;
    if (this.osobaForm.valid) {
      this.apiService.updateOsoba(this.osobaForm.value).subscribe(
        (res) =>{ this.alertifyService.warning('Особа је успешно измењена!');console.log(res)},
        (err) => {this.alertifyService.error('Дошло је до грешке');
        }
      );
    } else {
      this.alertifyService.error('Дошло је до грешке');
    }
  }

  resetFormValues(): void {
    this.osobaForm.reset();
  }

}
