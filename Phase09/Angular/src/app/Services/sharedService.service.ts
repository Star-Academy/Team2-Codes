import { Injectable } from '@angular/core';
import { Document } from '../Models/result-item';

@Injectable({
    providedIn: 'root'
})
export class SharedService {
    public results: Document[];
    public query: string;

    public getResults(): Document[] {
        return this.results;
    }

    public setResults(results: Document[]) {
        this.results = results;
    }
    
    public getQuery(): string {
        return this.query;
    }

    public setQuery(query: string) {
        this.query = query;
    }
}