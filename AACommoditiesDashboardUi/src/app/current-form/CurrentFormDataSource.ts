import { CurrentForm } from "./../model/CurrentForm";
import { EMPTY } from "rxjs";
import { map } from "rxjs/operators";
import { Observable, BehaviorSubject, combineLatest } from "rxjs";
import { DataSource } from "@angular/cdk/table";

export class CurrentFormDataSource extends DataSource<CurrentForm> {
    private dataStream: Observable<CurrentForm[]> = EMPTY;
    public modelFilter$: BehaviorSubject<number> = new BehaviorSubject(-1);
    public commodityFilter$: BehaviorSubject<number> = new BehaviorSubject(-1);

    constructor(initialData$: Observable<CurrentForm[]>) {
        super();
        this.dataStream = combineLatest([
            initialData$,
            this.modelFilter$,
            this.commodityFilter$,
        ]).pipe(
            map(([data, modelId, commodityId]) => {
                return data
                    .filter((d) => modelId === -1 || d.modelId === modelId)
                    .filter(
                        (d) =>
                            commodityId === -1 || d.commodityId === commodityId
                    );
            })
        );
    }

    connect(): Observable<CurrentForm[]> {
        return this.dataStream;
    }

    disconnect() {}
}
