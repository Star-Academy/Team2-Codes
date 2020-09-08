import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { SearchService } from '../Services/webConnection.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {
  query: string;

  constructor(private service: SearchService, private router: Router) { }

  docIds: string[];

  ngOnInit(): void {
  }

  search(event: KeyboardEvent) {
    if (event.key === "Enter") {
      this.service.search(this.query, 1).subscribe(ans => {
        this.docIds = ans
        localStorage.setItem('results', this.docIds.join(','));
        localStorage.setItem('query', this.query);
        this.router.navigate(['/result']);
      });
    }
  }
}
