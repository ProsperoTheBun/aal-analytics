import { HistoricalMetrics } from "../model/HistoricalMetrics";
import { Observable } from "rxjs";
import { Component, Input, OnInit } from "@angular/core";
import * as Highcharts from "highcharts";

@Component({
    selector: "app-timeseries-chart",
    templateUrl: "./timeseries-chart.component.html",
    styleUrls: ["./timeseries-chart.component.scss"],
})
export class TimeseriesChartComponent implements OnInit {
    @Input() datasource$!: Observable<HistoricalMetrics[]>;
    @Input() title: string = "";
    Highcharts: typeof Highcharts = Highcharts;
    chartConstructor: string = "chart";
    chartOptions: Highcharts.Options = {
        title: { text: this.title },
        series: [
            {
                data: [],
                type: "line",
            },
            {
                data: [],
                type: "line",
            },
            {
                data: [],
                type: "line",
            },
        ],
    };
    chart!: Highcharts.Chart;
    chartCallback: Highcharts.ChartCallbackFunction;
    updateFlag = false;

    constructor() {
        const self = this;
        this.chartCallback = (chart) => {
            self.chart = chart;
        };
    }

    ngOnInit(): void {
        this.datasource$.subscribe((data) => {
            const mappedData: Highcharts.SeriesOptionsType[] = data.map(
                (commodity) => ({
                    data: commodity.values,
                    type: "line",
                    name: commodity.name,
                    color:
                        {
                            Gold: "gold",
                            Oil: "black",
                            Coffee: "brown",
                        }[commodity.name] ?? "red",
                })
            );
            this.chartOptions.series = mappedData;
            this.updateFlag = true;
        });

        this.chartOptions.title = { text: this.title };
    }

    updateData(data: Highcharts.SeriesOptionsType[]) {
        this.chartOptions.series = data;
        this.updateFlag = true;
    }
}
