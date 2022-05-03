import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CurrentFormComponent } from "./current-form/current-form.component";
import { HistoricalTrendsComponent } from "./historical-trends/historical-trends.component";
import { HomeComponent } from "./home/home.component";

@NgModule({
    imports: [
        RouterModule.forRoot([
            { path: "", component: HomeComponent, pathMatch: "full" },
            { path: "historical-trends", component: HistoricalTrendsComponent },
            { path: "current-form", component: CurrentFormComponent },
        ]),
    ],
    exports: [RouterModule],
})
export class AppRoutingModule {}
