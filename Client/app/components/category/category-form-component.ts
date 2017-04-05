import { Component, OnDestroy, OnInit } from "@angular/core";
import { FlashMessagesServices } from "@angular2-flash-messages";
import { ActivatedRoute } from "@angular/router";
import { HttpCommonService } from "../../shared/services/http-common.service";

@Component({
    moduleId: module.id,
    selector: "category-form",
    templateUrl: "category-form-template.html",
    providers: [HttpCommonService]
})

export class CategoryFromComponents {
    public apiName: string
    protected model = {};
    protected submited = false;
    private sub: any;
    id: number;

    constructor(private _httpCommonService: HttpCommonService,
             private _flashMessagesServices: FlashMessagesServices,
             private _route: ActivatedRoute)
    {
        this.apiName = "admin/category";
        this.sub = _route.params.subscribe(params => {
            this.id = +params["id"];
            if (this.id > 0) {
                _httpCommonService.getItem(this.apiName + "/get", this.id).subscribe(data => {
                    this.model = data;
                },
                    err => {
                        this.showError(err);
                    });
            }
        })
    }
}

