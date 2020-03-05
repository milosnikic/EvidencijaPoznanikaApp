export class Osoba{
    id: number;
    maticniBroj: string;
    ime: string;
    prezime: string;
    visina: number;
    tezina: number;
    bojaOciju: string;
    telefon: string;
    email: string;
    rodjendan: Date;
    adresa: string;
    prebivaliste: string;

    constructor(id: number, maticniBroj: string, ime:string, prezime:string, visina:number, tezina:number, bojaOciju:string, telefon:string, email: string, rodjendan:Date, adresa:string, prebivaliste: string)
    {
        this.id  = id;
        this.maticniBroj = maticniBroj;
        this.ime = ime;
        this.prezime = prezime;
        this.visina = visina;
        this.tezina = tezina;
        this.bojaOciju = bojaOciju ;
        this.telefon = telefon;
        this.email = email;
        this.rodjendan = rodjendan;
        this.adresa = adresa;
        this.prebivaliste = prebivaliste;
    }
}