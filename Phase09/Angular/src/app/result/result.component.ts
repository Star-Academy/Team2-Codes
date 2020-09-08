import { Component, OnInit } from '@angular/core';
import { Document } from '../Models/result-item';
import { SharedService } from '../Services/sharedService.service';
import { SearchService } from '../Services/webConnection.service';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.scss']
})
export class ResultComponent implements OnInit {
  results: Document[];

  constructor(private sharedService: SharedService, private searchService: SearchService) { }

  ngOnInit(): void {
    this.results = this.sharedService.getResults();
  }

  search(query: string) {
    // console.log(query);
    let inputParts = query.split(', ');
    this.searchService.search(inputParts[0], Number.parseInt(inputParts[1])).subscribe(result => {
      this.results = result;
    })
  }
}
