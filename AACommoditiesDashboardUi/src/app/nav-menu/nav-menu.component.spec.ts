import { LayoutModule } from "@angular/cdk/layout";
import { waitForAsync, ComponentFixture, TestBed } from "@angular/core/testing";
import { NoopAnimationsModule } from "@angular/platform-browser/animations";
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule } from "@angular/material/icon";
import { MatListModule } from "@angular/material/list";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatToolbarModule } from "@angular/material/toolbar";

import { MatNavMenuComponent } from "./nav-menu.component";

describe("MatNavMenuComponent", () => {
    let component: MatNavMenuComponent;
    let fixture: ComponentFixture<MatNavMenuComponent>;

    beforeEach(waitForAsync(() => {
        TestBed.configureTestingModule({
            declarations: [MatNavMenuComponent],
            imports: [
                NoopAnimationsModule,
                LayoutModule,
                MatButtonModule,
                MatIconModule,
                MatListModule,
                MatSidenavModule,
                MatToolbarModule,
            ],
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(MatNavMenuComponent);
        component = fixture.componentInstance;
    });

    it("should compile", () => {
        expect(component).toBeTruthy();
    });
});
