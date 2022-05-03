import { of } from "rxjs";
import { CommoditiesService } from "./../services/commodities.service";
import { ComponentFixture, TestBed } from "@angular/core/testing";
import { CurrentFormComponent } from "./current-form.component";

describe("CurrentFormComponent", () => {
    let component: CurrentFormComponent;
    let fixture: ComponentFixture<CurrentFormComponent>;
    const mockService = { getCurrentForm: jest.fn() };

    beforeEach(async () => {
        TestBed.configureTestingModule({
            declarations: [CurrentFormComponent],
            providers: [{ provide: CommoditiesService, useValue: mockService }],
        });
        await TestBed.compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(CurrentFormComponent);
        component = fixture.componentInstance;
    });

    it("should create", () => {
        expect(component).toBeTruthy();
    });

    it("should call data service", () => {
        mockService.getCurrentForm.mockReturnValue(of([]));
        component.ngOnInit();
        expect(mockService.getCurrentForm.mock.calls.length).toBe(1);
    });
});
