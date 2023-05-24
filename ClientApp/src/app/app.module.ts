import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GlobalModule } from './modules/global/global.module';
import { HttpClient } from '@angular/common/http';
import { AuthGuard } from './auth/auth.guard';
import { AuthService } from './services/auth/auth.service';

const factory = (http: HttpClient) => new AuthService(http, '')

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    GlobalModule
  ],
  providers: [
    AuthGuard,
    {
      provide: AuthService,
      useFactory: factory,
      deps: [HttpClient],
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
