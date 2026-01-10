import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { Language } from "../models/language.model";
import { LanguageService } from "../services/language.service";

@Injectable({providedIn: "root"})
export class LangguageStateService{


    private languageSubject = new BehaviorSubject<Language[]>([]);
    languages$ = this.languageSubject.asObservable();


    constructor(private languageService: LanguageService){}

    loadLanguages() {
        this.languageService.getLanguages().subscribe({
            next: data => this.languageSubject.next(data),
            error: err => console.log(err)
        })
    }
}