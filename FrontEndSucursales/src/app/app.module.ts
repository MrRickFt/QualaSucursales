import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

// Modulos
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations'
import { ToastrModule } from 'ngx-toastr';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';


//Components
import { AppComponent } from './app.component';
import { InicioComponent } from './components/inicio/inicio.component';
import { BienvenidaComponent } from './components/inicio/bienvenida/bienvenida.component';
import { LoginComponent } from './components/inicio/login/login.component';
import { RegisterComponent } from './components/inicio/register/register.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { NavbarComponent } from './components/dashboard/navbar/navbar.component';
import { ProductosComponent } from './components/dashboard/productos/productos.component';
import { NuevoProductoComponent } from './components/dashboard/productos/nuevo-producto/nuevo-producto.component';
import { ProductoComponent } from './components/dashboard/productos/producto/producto.component';
import { LoadingComponent } from './shared/loading/loading.component';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { FiltroSucursalesPipe } from './pipe/filtro-sucursales.pipe';
import { AddTokenInterceptor } from './helpers/add-token.interceptor';





@NgModule({
  declarations: [
    AppComponent,
    InicioComponent,
    BienvenidaComponent,
    LoginComponent,
    RegisterComponent,
    DashboardComponent,
    NavbarComponent,
    ProductosComponent,
    NuevoProductoComponent,
    ProductoComponent,
    LoadingComponent,
    FiltroSucursalesPipe
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(), // ToastrModule added
    HttpClientModule,
    CommonModule,
    FormsModule,
    RouterModule,
    NgbPaginationModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: AddTokenInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
