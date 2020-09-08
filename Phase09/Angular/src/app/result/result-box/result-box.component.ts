import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-result-box',
  templateUrl: './result-box.component.html',
  styleUrls: ['./result-box.component.scss']
})
export class ResultBoxComponent implements OnInit {
  @Input()
  public docs: Document[];

  constructor() { }

  ngOnInit(): void {
  }

}
