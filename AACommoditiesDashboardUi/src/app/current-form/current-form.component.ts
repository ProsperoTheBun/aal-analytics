import { CurrentForm } from "./../model/CurrentForm";
import { Component, OnInit } from "@angular/core";
import { CommoditiesService } from "../services/commodities.service";
import { of, EMPTY } from "rxjs";
import { map } from "rxjs/operators";
import { Observable } from "rxjs";
import { CurrentFormDataSource } from "./CurrentFormDataSource";
import { ConfigurableFocusTrap } from "@angular/cdk/a11y";

@Component({
    selector: "app-current-form",
    templateUrl: "./current-form.component.html",
    styleUrls: ["./current-form.component.scss"],
})
export class CurrentFormComponent implements OnInit {
    public dataSource$: Observable<CurrentForm[]> = EMPTY;
    public tableDataSource!: CurrentFormDataSource;
    public displayedColumns: string[] = [
        "model",
        "name",
        "nta1",
        "nta2",
        "nta3",
        "nta4",
        "nta5",
    ];
    public commodities$: Observable<any[]> = EMPTY;
    public models$: Observable<any[]> = EMPTY;
    public selectedModel: Observable<number> = of(0);

    constructor(private commoditiesService: CommoditiesService) {}

    ngOnInit(): void {
        this.dataSource$ = this.commoditiesService.getCurrentForm();
        this.tableDataSource = new CurrentFormDataSource(this.dataSource$);

        this.commodities$ = this.dataSource$.pipe(
            map((data: CurrentForm[]) =>
                data.map((cf: CurrentForm) => ({
                    id: cf.commodityId,
                    name: cf.commodityName,
                }))
            )
        );

        this.models$ = this.dataSource$.pipe(
            map((data: CurrentForm[]) => {
                const models = data.map((cf: CurrentForm) => ({
                    id: cf.modelId,
                    name: cf.modelName,
                }));
                const distinctModels = models.filter(
                    (value, index, arr) =>
                        arr.findIndex((v) => v.id === value.id) === index
                );
                return distinctModels;
            })
        );
    }

    onModelChange(event: any): void {
        this.tableDataSource.modelFilter$.next(event.value);
    }

    onCommodityChange(event: any): void {
        this.tableDataSource.commodityFilter$.next(event.value);
    }
}
