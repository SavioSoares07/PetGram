import { NgModule } from '@angular/core';
import { AppRoutingModule } from '../app-routing.module';
import { HeaderAccountComponent } from './header-account/header-account.component';
import { AnguarMaterialModule } from '../angular-material/angular-material.module';

@NgModule({
  declarations: [HeaderAccountComponent],
  imports: [AppRoutingModule, AnguarMaterialModule],
  exports: [HeaderAccountComponent],
})
export class Components {}
