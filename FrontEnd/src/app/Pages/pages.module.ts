import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SigninComponent } from './signin/signin.component';
import { SignupComponent } from './signup/signup.component';
import { Components } from '../components/components.module';
import { AnguarMaterialModule } from '../angular-material/angular-material.module';

@NgModule({
  declarations: [SigninComponent, SignupComponent],
  imports: [CommonModule, Components, AnguarMaterialModule],
  exports: [SigninComponent, SignupComponent, AnguarMaterialModule],
})
export class PagesModule {}
