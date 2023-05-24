import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GlobalModule } from './modules/global/global.module';
import { HttpClient } from '@angular/common/http';
import { AuthGuard } from './auth/auth.guard';
import { AuthService } from './services/auth/auth.service';
import { MenuService } from './services/menu/menu.service';
import { ClienteModule } from './modules/cliente/cliente.module';
import { ClientesService } from './services/clientes/clientes.service';

const factory = (http: HttpClient) => new AuthService(http)
const factory2 = (http: HttpClient) => new AuthService(http)
const factory3 = (http: HttpClient) => new ClientesService(http)

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    GlobalModule,
    ClienteModule
  ],
  providers: [
    AuthGuard,
    {
      provide: AuthService,
      useFactory: factory,
      deps: [HttpClient],
    },
    {
      provide: MenuService,
      useFactory: factory2,
      deps: [HttpClient],
    },
    {
      provide: ClientesService,
      useFactory: factory3,
      deps: [HttpClient],
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
