import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { EMPTY, Observable } from "rxjs";
import { catchError } from "rxjs/operators";
import { environment } from "../../environments/environment";
import { HistoricalMetrics, KeyMetric, CurrentForm } from "../model";

@Injectable({
    providedIn: "root",
})
export class CommoditiesService {
    constructor(private httpClient: HttpClient) {}

    public getHistoricalPosition(): Observable<HistoricalMetrics[]> {
        return this.httpClient
            .get<HistoricalMetrics[]>(
                environment.commoditiesApi + "historicalposition"
            )
            .pipe(catchError((err) => this.displayError(err)));
    }

    public getKeyMetrics(): Observable<KeyMetric[]> {
        return this.httpClient
            .get<KeyMetric[]>(environment.commoditiesApi + "keymetrics")
            .pipe(catchError((err) => this.displayError(err)));
    }

    public getHistoricalProfitAndLoss(): Observable<HistoricalMetrics[]> {
        return this.httpClient
            .get<HistoricalMetrics[]>(
                environment.commoditiesApi + "historicalpnl"
            )
            .pipe(catchError((err) => this.displayError(err)));
    }

    public getCurrentForm(): Observable<CurrentForm[]> {
        return this.httpClient
            .get<CurrentForm[]>(environment.commoditiesApi + "currentform")
            .pipe(catchError((err) => this.displayError(err)));
    }

    private displayError(err: any) {
        console.error(err);
        return EMPTY;
    }
}
