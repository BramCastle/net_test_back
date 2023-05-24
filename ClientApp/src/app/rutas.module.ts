import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { globalRoutes } from './modules/global/global.routing';
import { clientesRoutes } from './modules/cliente/cliente.routing';

@NgModule({
    imports: [
        RouterModule.forChild([
            ...globalRoutes,
            ...clientesRoutes,
        ])
    ],
    providers: [],
    exports: [RouterModule]
})
export class RutasModule { }
