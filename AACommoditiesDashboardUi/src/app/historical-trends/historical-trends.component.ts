import { HistoricalMetrics } from "../model/HistoricalMetrics";
import { Observable } from "rxjs";
import { Component } from "@angular/core";
import { CommoditiesService } from "../services/commodities.service";

@Component({
    selector: "app-historical-trends",
    templateUrl: "./historical-trends.component.html",
    styleUrls: ["./historical-trends.component.scss"],
})
export class HistoricalTrendsComponent {
    public get pnlData$(): Observable<HistoricalMetrics[]> {
        return this.commoditiesService.getHistoricalProfitAndLoss();
    }

    public get positionData$(): Observable<HistoricalMetrics[]> {
        return this.commoditiesService.getHistoricalPosition();
    }

    constructor(private commoditiesService: CommoditiesService) {}
}
