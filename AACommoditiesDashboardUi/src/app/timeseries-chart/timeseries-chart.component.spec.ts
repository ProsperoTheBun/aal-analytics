import { ComponentFixture, TestBed } from "@angular/core/testing";

import { TimeseriesChartComponent } from "./timeseries-chart.component";

describe("TimeseriesChartComponent", () => {
    let component: TimeseriesChartComponent;
    let fixture: ComponentFixture<TimeseriesChartComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [TimeseriesChartComponent],
        }).compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(TimeseriesChartComponent);
        component = fixture.componentInstance;
    });

    it("should create", () => {
        expect(component).toBeTruthy();
    });
});
