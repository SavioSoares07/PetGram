import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SigninComponent } from './signin/signin.component';
import { SignupComponent } from './signup/signup.component';
import { Components } from '../components/components.module';
import { AnguarMaterialModule } from '../angular-material/angular-material.module';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [SigninComponent, SignupComponent],
  imports: [CommonModule, Components, AnguarMaterialModule, RouterModule],
  exports: [SigninComponent, SignupComponent, AnguarMaterialModule],
})
export class PagesModule {}
