import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './footer/footer.component';
import { SearchComponent } from './search/search.component';
import { ResultComponent } from './result/result.component';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import {SearchService} from './Services/webConnection.service';
import { ResultBoxComponent } from './result/result-box/result-box.component';
import { SearchBoxComponent } from './result/search-box/search-box.component';
import { ResultCardComponent } from './result/result-box/result-card/result-card.component';
import { SharedService } from './Services/sharedService.service';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    SearchComponent,
    ResultComponent,
    ResultBoxComponent,
    SearchBoxComponent,
    ResultCardComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    SearchService,
    SharedService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
