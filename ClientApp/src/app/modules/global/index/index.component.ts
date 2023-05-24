import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth/auth.service';
import { MenuService } from 'src/app/services/menu/menu.service';


@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})

export class IndexComponent implements OnInit {
  menus = new Array<any>();

  constructor(private _menuService : AuthService) { }


  ngOnInit() {
    this.menuIndex();
  }

  menuIndex(){
    this._menuService.index().subscribe(res => {
      this.menus = res.result;
    });
  }

}
