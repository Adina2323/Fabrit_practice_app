import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})

export class ApiService{
    apiUrl = 'https://localhost:7289/api';

    constructor(private http: HttpClient){}

    getHeroes() : Observable<any[]>
    {
        return this.http.get<any[]>(`${this.apiUrl}/Heroes`);
    }

    getHeroById(id : number) : Observable<any>
    {
        return this.http.get<any>(`${this.apiUrl}/Heroes/${id}`);
    }

    addHero(hero : any) : Observable<any>
    {
        return this.http.post<any>(`${this.apiUrl}/Heroes`, hero);
    }

    updateHero(id : number, hero : any) : Observable<any>
    {
        return this.http.put<any>(`${this.apiUrl}/Heroes/${id}`, hero);
    }

    deleteHero(id : number) : Observable<any>
    {
        return this.http.delete<any>(`${this.apiUrl}/Heroes/${id}`);
    }

}