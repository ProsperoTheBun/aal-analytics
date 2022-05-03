import { EMPTY } from "rxjs";
import { ComponentFixture, TestBed } from "@angular/core/testing";
import { CommoditiesService } from "./../services/commodities.service";
import { HistoricalTrendsComponent } from "./historical-trends.component";

describe("HistoricalTrendsComponent", () => {
    let component: HistoricalTrendsComponent;
    let fixture: ComponentFixture<HistoricalTrendsComponent>;
    const mockService = {
        getHistoricalPosition: jest.fn(),
        getHistoricalProfitAndLoss: jest.fn(),
    };

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [HistoricalTrendsComponent],
            providers: [{ provide: CommoditiesService, useValue: mockService }],
        }).compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(HistoricalTrendsComponent);
        component = fixture.componentInstance;
    });

    it("should create", () => {
        expect(component).toBeTruthy();
    });

    it("should call service for position data", () => {
        component.positionData$;
        expect(mockService.getHistoricalPosition.mock.calls.length).toBe(1);
    });

    it("should call service for pnl data", () => {
        component.pnlData$;
        expect(mockService.getHistoricalProfitAndLoss.mock.calls.length).toBe(1);
    });
});
