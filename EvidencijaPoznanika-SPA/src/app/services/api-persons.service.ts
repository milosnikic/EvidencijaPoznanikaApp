import { AlertifyService } from "./alertify.service";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Osoba } from "src/models/osoba";
import { HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Injectable({
  providedIn: "root"
})
export class ApiPersonsService {
  baseUrl = "http://localhost:5000/api/osoba/";
  constructor(
    private http: HttpClient,
    private alertifyService: AlertifyService
  ) {}

  updateOsoba(osoba: Osoba) {
    return this.http.put(this.baseUrl + "update", osoba, httpOptions);
  }

  insertOsoba(osoba: Osoba) {
    return this.http.post(this.baseUrl + "insert", osoba);
  }
  getOsoba(id: number) {
    return this.http.get<Osoba>(this.baseUrl + id);
  }

  getOsobe() {
    return this.http.get<Osoba[]>(this.baseUrl);
  }

  getSmederevci() {
    return this.http.get<Osoba[]>(this.baseUrl + "smederevci");
  }

  getPunoletni() {
    return this.http.get<Osoba[]>(this.baseUrl + "punoletni");
  }

  getSrednjaStarost() {
    return this.http.get<number>(this.baseUrl + "srednjaStarost");
  }

  getMaxVisina() {
    return this.http.get<number>(this.baseUrl + "maxVisina");
  }

  deleteOsoba(id: number) {
    return this.http.delete(this.baseUrl + id).subscribe(
      res => {
        console.log(res);
      },
      err => {
        console.log(err);
      }
    );
  }
}
