import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  serverAns: string[] = [
    'hello',
    'javad',
    'amir',
    'test',
    'mock service'
  ]

  ids: string[];

  constructor() { }

  search(query: string) {
    console.log(query);
  }
}
