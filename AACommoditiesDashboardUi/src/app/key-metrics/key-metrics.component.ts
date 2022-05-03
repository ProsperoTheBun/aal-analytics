import { map } from "rxjs/operators";
import { Component, OnInit } from "@angular/core";
import { CommoditiesService } from "../services/commodities.service";
import { KeyMetricDataSource } from "./KeyMetricDataSource";

@Component({
    selector: "app-key-metrics",
    templateUrl: "./key-metrics.component.html",
    styleUrls: ["./key-metrics.component.scss"],
})
export class KeyMetricsComponent implements OnInit {
    public dataSource$!: KeyMetricDataSource;
    public displayedColumns: string[] = [
        "name",
        "model",
        "date",
        "profitAndLoss",
        "profitAndLossYearToDate",
    ];
    constructor(private commoditiesService: CommoditiesService) {}

    ngOnInit(): void {
        this.dataSource$ = new KeyMetricDataSource(
            this.commoditiesService.getKeyMetrics().pipe(
                map((data) => {
                    const maxPnl = Math.max(
                        ...data.map((d) => d.profitAndLoss)
                    );
                    const maxPnlYtd = Math.max(
                        ...data.map((d) => d.profitAndLossYearToDate)
                    );
                    return data.map((d) => {
                        d.isProfitAndLossHighlight = d.profitAndLoss === maxPnl;
                        d.isProfitAndLossYearToDateHighlight =
                            d.profitAndLossYearToDate === maxPnlYtd;
                        return d;
                    });
                })
            )
        );
    }
}
