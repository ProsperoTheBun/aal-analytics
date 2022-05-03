import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { HomeComponent } from "./home/home.component";
import { HistoricalTrendsComponent } from "./historical-trends/historical-trends.component";
import { CurrentFormComponent } from "./current-form/current-form.component";
import { KeyMetricsComponent } from "./key-metrics/key-metrics.component";
import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatNavMenuComponent as NavMenuComponent } from "./nav-menu/nav-menu.component";
import { LayoutModule } from "@angular/cdk/layout";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatButtonModule } from "@angular/material/button";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatIconModule } from "@angular/material/icon";
import { MatListModule } from "@angular/material/list";
import { MatTableModule } from "@angular/material/table";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatSortModule } from "@angular/material/sort";
import { TopMenuComponent } from "./top-menu/top-menu.component";
import { HighchartsChartModule } from "highcharts-angular";
import { TimeseriesChartComponent } from "./timeseries-chart/timeseries-chart.component";
import { MatSelectModule } from "@angular/material/select";

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        HistoricalTrendsComponent,
        CurrentFormComponent,
        KeyMetricsComponent,
        NavMenuComponent,
        TopMenuComponent,
        TimeseriesChartComponent,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        BrowserAnimationsModule,
        LayoutModule,
        MatToolbarModule,
        MatButtonModule,
        MatSidenavModule,
        MatIconModule,
        MatListModule,
        MatTableModule,
        MatPaginatorModule,
        MatSortModule,
        MatSelectModule,
        HighchartsChartModule,
    ],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
