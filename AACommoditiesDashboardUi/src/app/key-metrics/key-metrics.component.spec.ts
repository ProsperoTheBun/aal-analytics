import { ComponentFixture, TestBed } from "@angular/core/testing";
import { CommoditiesService } from "./../services/commodities.service";
import { KeyMetricsComponent } from "./key-metrics.component";

describe("KeyMetricsComponent", () => {
    let component: KeyMetricsComponent;
    let fixture: ComponentFixture<KeyMetricsComponent>;
    const mockService = { getCurrentForm: jest.fn() };

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [KeyMetricsComponent],
            providers: [{ provide: CommoditiesService, useValue: mockService }],
        }).compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(KeyMetricsComponent);
        component = fixture.componentInstance;
    });

    it("should create", () => {
        expect(component).toBeTruthy();
    });
});
