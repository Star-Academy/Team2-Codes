import { Component, OnInit, Input } from '@angular/core';
import { Document } from '../../../Models/result-item';

@Component({
  selector: 'app-result-card',
  templateUrl: './result-card.component.html',
  styleUrls: ['./result-card.component.scss']
})
export class ResultCardComponent implements OnInit {
  @Input()
  public doc: Document;

  constructor() { }

  ngOnInit(): void {
  }
}
