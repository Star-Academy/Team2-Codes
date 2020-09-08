import { Component, OnInit } from '@angular/core';
import { Document } from '../Models/result-item';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.scss']
})
export class ResultComponent implements OnInit {
  docs: Document[];
  query: string;

  constructor() { }

  ngOnInit(): void {
    let docIds = localStorage.getItem('results').split(',');
    this.docs = [];
    for (let doc of docIds) {
      let temp = new Document();
      temp.id = doc;
      temp.content = 'hello world';
      this.docs.push(temp);
    }

    this.query = localStorage.getItem('query');
  }
}
