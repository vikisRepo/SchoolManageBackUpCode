import { BrowserModule } from '@angular/platform-browser';
import {CommonModule} from '@angular/common'
import { APP_INITIALIZER, CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { SimpleNotificationsModule} from 'angular2-notifications';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SigninComponent } from './components/signin/signin.component';
import { RegisterComponent } from './components/register/register.component';
import { AngularMaterialModule } from '../angular-material.module';
import { LoginFormComponent } from './login-form/login-form.component';
import { HttpClientModule,HTTP_INTERCEPTORS } from '@angular/common/http';
import { MainComponent } from './components/mainpage/mainpage.component';
import { AngularFileUploaderModule } from "angular-file-uploader";
import { BlockUIModule } from 'ng-block-ui';
import { AlertModule } from './shared/alert/alert.module';

import { fakeBackendProvider } from '../app/_helpers';

import { JwtInterceptor, ErrorInterceptor, appInitializer } from '../app/_helpers';
import { AccountService } from '../app/_services';
import { AlertComponent } from '../app/_components';
import { HomeComponent } from '../app/home';

import { AvatarModule } from 'ngx-avatar';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';


@NgModule({
  declarations: [
    AppComponent,
    SigninComponent,
    RegisterComponent,
    LoginFormComponent,
    MainComponent,
   AlertComponent,
   HomeComponent

  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    AngularMaterialModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AngularFileUploaderModule,
    BlockUIModule.forRoot(),
    AlertModule,
    // AlertComponent,
    // HomeComponent,
    SimpleNotificationsModule.forRoot(),
    AvatarModule.forRoot(),
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory,
    })
     //HomeComponent
  ],
  providers: [
    { provide: APP_INITIALIZER, useFactory: appInitializer, multi: true, deps: [AccountService] },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },

    // provider used to create fake backend
    fakeBackendProvider
  ],
  bootstrap: [AppComponent],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class AppModule { }
