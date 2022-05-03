import { Observable } from "rxjs";
import { DataSource } from '@angular/cdk/table';
import {KeyMetric} from '../model/KeyMetric';

export class KeyMetricDataSource extends DataSource<KeyMetric> {
    private _dataStream;

    constructor(initialData: Observable<KeyMetric[]>) {
        super();
        this._dataStream = initialData;
    }

    connect(): Observable<KeyMetric[]> {
        return this._dataStream;
    }

    disconnect() { }
}
