import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Document } from '../Models/result-item';

@Injectable()
export class SearchService {
    baseApi = 'http://localhost:5000/api/'

    constructor(private httpClient: HttpClient) { };

    search(query: string, page: number): Observable<any> {
        return this.httpClient.get(`${this.baseApi}InvertedIndex/documents/search?query=${query}&size=10&page=${page}`, {})
    }
}