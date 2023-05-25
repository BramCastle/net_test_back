import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GlobalModule } from '../global/global.module';
import { IndexComponent } from './index/index.component';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    GlobalModule,
    RouterModule,
  ],
  declarations: [IndexComponent]
})
export class ClienteModule { }
