import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { SharedService } from 'src/app/Services/sharedService.service';

@Component({
  selector: 'app-search-box',
  templateUrl: './search-box.component.html',
  styleUrls: ['./search-box.component.scss']
})
export class SearchBoxComponent implements OnInit {
  @Output()
  public searched = new EventEmitter<string>();
  
  query: string;
  pageNum: number = 1;

  constructor(private sharedService: SharedService) { }

  ngOnInit(): void {
    this.query = this.sharedService.getQuery();
  }

  checkEnter(event: KeyboardEvent) {
    if (event.key !== "Enter") return;
    this.searched.emit(`${this.query}, ${this.pageNum}`);
  }
}
