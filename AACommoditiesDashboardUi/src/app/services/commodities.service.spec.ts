import { HistoricalMetrics } from "./../model/HistoricalMetrics";
import { HttpClient } from "@angular/common/http";
import { TestBed } from "@angular/core/testing";
import { of } from "rxjs";
import { CommoditiesService } from "./commodities.service";

describe("CommoditiesService", () => {
    const mockHttpClient = { get: jest.fn() };

    beforeEach(async () => {
        TestBed.configureTestingModule({
            providers: [{ provide: HttpClient, useValue: mockHttpClient }],
        });
        await TestBed.compileComponents();
    });

    it("should be created", () => {
        const service: CommoditiesService = TestBed.inject(CommoditiesService);
        expect(service).toBeTruthy();
    });

    describe("getHistoricalPosition", () => {
        it("should call get endpoint", () => {
            const expectedMetrics: HistoricalMetrics[] = [
                { commodityId: 1, name: "first", values: [1, 2, 3] },
            ];
            mockHttpClient.get.mockReturnValue(of(expectedMetrics));

            const service: CommoditiesService =
                TestBed.inject(CommoditiesService);
            service.getHistoricalPosition().subscribe((data) => {
                expect(data).toEqual(expectedMetrics);
                expect(data.length).toBe(3);
            });

            expect(mockHttpClient.get.mock.calls.length).toBe(1);
        });
    });

    // remaining tests ommitted for code exercise
});
