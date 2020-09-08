import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {
  @Output()
  public searched = new EventEmitter<string>();

  query: string;
  
  constructor() { }

  ngOnInit(): void {
  }

  search (event: KeyboardEvent) {
    if (event.key === "Enter") {
      this.searched.emit(this.query);
    }
  }


}
