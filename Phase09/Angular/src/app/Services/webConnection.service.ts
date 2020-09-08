import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Document } from '../Models/result-item';

@Injectable()
export class SearchService {
    baseApi = 'http://localhost:5000/api/'
    // results: Document[] = [];

    constructor(private httpClient: HttpClient) { };

    // http://localhost:13649/api/InvertedIndex/documents/search?query=hello&size=10&page=2

    search(query: string, page: number): Observable<any> {
        return this.httpClient.get(`${this.baseApi}InvertedIndex/documents/search?query=${query}&size=10&page=${page}`, {})
    }
}