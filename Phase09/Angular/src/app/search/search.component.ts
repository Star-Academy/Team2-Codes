import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { SearchService } from '../Services/webConnection.service';
import { Router } from '@angular/router';
import { SharedService } from '../Services/sharedService.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {
  query: string;

  constructor(private service: SearchService, private shardService: SharedService, private router: Router) { }

  ngOnInit(): void {
  }

  search(event: KeyboardEvent) {
    if (event.key === "Enter") {
      this.service.search(this.query, 1).subscribe(results => {
        this.shardService.setResults(results);
        this.shardService.setQuery(this.query);
        this.router.navigate(['/result']);
      });
    }
  }
}
