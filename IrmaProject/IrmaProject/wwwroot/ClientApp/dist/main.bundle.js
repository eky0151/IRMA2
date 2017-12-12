webpackJsonp(["main"],{

/***/ "../../../../../ClientApp/$$_lazy_route_resource lazy recursive":
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncatched exception popping up in devtools
	return Promise.resolve().then(function() {
		throw new Error("Cannot find module '" + req + "'.");
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "../../../../../ClientApp/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "../../../../../ClientApp/app/albumlist/albumlist.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"row\">\r\n    <table class=\"table table-striped table-hover\">\r\n        <thead>\r\n            <tr>\r\n                <th>Name</th>\r\n                <th>Description</th>\r\n                <th>Files in album</th>\r\n                <th>Created</th>\r\n                <th>Last modified</th>\r\n                <th class=\"text-right\"><button type=\"button\" class=\"btn btn-primary\" data-toggle=\"modal\" data-target=\"#createAlbumModal\">New</button></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody *ngFor=\"let p of albums\">\r\n            <tr data-toggle=\"collapse\" [attr.data-target]=\"'#' + p.name\">\r\n                <td>{{ p.name }}</td>\r\n                <td>{{ p.description }}</td>\r\n                <td>{{ p.filesCount }}</td>\r\n                <td>{{ p.createdAt }}</td>\r\n                <td>{{ p.modifiedAt }}</td>\r\n                <td>\r\n                    <div class=\"modal fade\" [attr.id]=\"'uploadImageModal' + p.name\" tabindex=\"-1\" role=\"dialog\" [attr.aria-labelledby]=\"'uploadImageModalLabel' + p.name\" aria-hidden=\"true\">\r\n                        <div class=\"modal-dialog\" role=\"document\">\r\n                            <div class=\"modal-content\">\r\n                                <form action=\"/api/album/uploadimage\" enctype=\"multipart/form-data\" method=\"post\">\r\n                                    <div class=\"modal-header\">\r\n                                        <h5 class=\"modal-title\" id=\"uploadImageModalLabel\">Upload image</h5>\r\n                                        <button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\">\r\n                                            <span aria-hidden=\"true\">&times;</span>\r\n                                        </button>\r\n                                    </div>\r\n                                    <div class=\"modal-body\">\r\n                                        <input type=\"hidden\" name=\"albumname\" [attr.value]=\"p.name\" />\r\n                                        <label>Image name:</label><input type=\"text\" name=\"imageName\" />\r\n                                        <input class=\"btn btn-default\" type=\"file\" name=\"file\" />\r\n                                    </div>\r\n                                    <div class=\"modal-footer\">\r\n                                        <button type=\"submit\" class=\"btn btn-primary\">Upload</button>\r\n                                    </div>\r\n                                </form>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </td>\r\n            </tr>\r\n                <!--<td *ngFor=\"let i of p.images\" id=\"imageContainer{{ p.name }}\" class=\"collapse\">{{ i.name }}</td>-->\r\n            <tr class=\"collapse\" style=\"background-color:white\" [attr.id] = \"p.name\">\r\n                <td></td>\r\n                <td colspan=\"6\">\r\n                    <table class=\"table table-striped table-hover\">\r\n                        <thead>\r\n                            <tr>\r\n                                <th></th>\r\n                                <th>Name</th>\r\n                                <th>Tags</th>\r\n                                <th>Width</th>\r\n                                <th>Height</th>\r\n                                <th>Uploaded at</th>\r\n                                <th class=\"text-right\"><button type=\"button\" class=\"btn btn-default\" data-toggle=\"modal\" [attr.data-target]=\"'#uploadImageModal' + p.name\">Upload</button></th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tr *ngFor=\"let i of p.images\">\r\n                            <td><img src=\"{{ i.url }}\" width=\"80\" height=\"80\" alt=\"{{ i.name }}\" /></td>\r\n                            <td>{{ i.name }}</td>\r\n                            <td width=\"130px\"><span class=\"badge\" *ngFor=\"let t of i.tags\">{{ t }}</span></td>\r\n                            <td class=\"text-right\">{{ i.width }}</td>\r\n                            <td class=\"text-right\">{{ i.height }}</td>\r\n                            <td colspan=\"2\" class=\"text-right\">{{ i.uploadedAt }}</td>\r\n                        </tr>\r\n                    </table>\r\n                </td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n</div>\r\n\r\n<div class=\"modal fade\" id=\"createAlbumModal\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"createAlbumModal\" aria-hidden=\"true\">\r\n    <div class=\"modal-dialog\" role=\"document\">\r\n        <div class=\"modal-content\">\r\n            <form action=\"/api/album/create\" method=\"post\">\r\n                <div class=\"modal-header\">\r\n                    <h5 class=\"modal-title\" id=\"uploadImageModalLabel\">Upload image</h5>\r\n                    <button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\">\r\n                        <span aria-hidden=\"true\">&times;</span>\r\n                    </button>\r\n                </div>\r\n                <div class=\"modal-body\">\r\n                    <input type=\"hidden\" name=\"userId\" value=\"@Model.Userid\" />\r\n                    <label>Album name:</label><input type=\"text\" name=\"albumName\" />\r\n                </div>\r\n                <div class=\"modal-footer\">\r\n                    <button type=\"submit\" class=\"btn btn-primary\">Create</button>\r\n                </div>\r\n            </form>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"modal fade\" id=\"uploadImageModal\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"uploadImageModalLabel\" aria-hidden=\"true\">\r\n    <div class=\"modal-dialog\" role=\"document\">\r\n        <div class=\"modal-content\">\r\n            <form action=\"/api/album/uploadimage\" enctype=\"multipart/form-data\" method=\"post\">\r\n                <div class=\"modal-header\">\r\n                    <h5 class=\"modal-title\" id=\"uploadImageModalLabel\">Upload image</h5>\r\n                    <button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\">\r\n                        <span aria-hidden=\"true\">&times;</span>\r\n                    </button>\r\n                </div>\r\n                <div class=\"modal-body\">\r\n                    <input type=\"hidden\" name=\"albumId\" value=\"@Model.AlbumId\" />\r\n                    <label>Image name:</label><input type=\"text\" name=\"imageName\" />\r\n                    <input class=\"btn btn-default\" type=\"file\" name=\"file\" />\r\n                </div>\r\n                <div class=\"modal-footer\">\r\n                    <button type=\"submit\" class=\"btn btn-primary\">Upload</button>\r\n                </div>\r\n            </form>\r\n        </div>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "../../../../../ClientApp/app/albumlist/albumlist.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AlbumList; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__shared_dataService__ = __webpack_require__("../../../../../ClientApp/app/shared/dataService.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var AlbumList = (function () {
    function AlbumList(data) {
        this.data = data;
        this.albums = data.albums;
    }
    AlbumList.prototype.ngOnInit = function () {
        var _this = this;
        this.data.loadAlbums()
            .subscribe(function (success) {
            if (success) {
                _this.albums = _this.data.albums;
            }
        });
    };
    AlbumList = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["m" /* Component */])({
            selector: "album-list",
            template: __webpack_require__("../../../../../ClientApp/app/albumlist/albumlist.component.html"),
            styleUrls: []
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__shared_dataService__["a" /* DataService */]])
    ], AlbumList);
    return AlbumList;
}());



/***/ }),

/***/ "../../../../../ClientApp/app/app.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"row\">\r\n    <div>\r\n        <h1>{{title}}</h1>\r\n        <album-list></album-list>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "../../../../../ClientApp/app/app.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var AppComponent = (function () {
    function AppComponent() {
        this.title = 'Albums';
    }
    AppComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["m" /* Component */])({
            selector: 'app-root',
            template: __webpack_require__("../../../../../ClientApp/app/app.component.html"),
            styles: []
        })
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "../../../../../ClientApp/app/app.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_platform_browser__ = __webpack_require__("../../../platform-browser/esm5/platform-browser.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_common_http__ = __webpack_require__("../../../common/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__app_component__ = __webpack_require__("../../../../../ClientApp/app/app.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__albumlist_albumlist_component__ = __webpack_require__("../../../../../ClientApp/app/albumlist/albumlist.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__shared_dataService__ = __webpack_require__("../../../../../ClientApp/app/shared/dataService.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};






var AppModule = (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["E" /* NgModule */])({
            declarations: [
                __WEBPACK_IMPORTED_MODULE_3__app_component__["a" /* AppComponent */],
                __WEBPACK_IMPORTED_MODULE_4__albumlist_albumlist_component__["a" /* AlbumList */],
            ],
            imports: [
                __WEBPACK_IMPORTED_MODULE_0__angular_platform_browser__["a" /* BrowserModule */],
                __WEBPACK_IMPORTED_MODULE_2__angular_common_http__["b" /* HttpClientModule */]
            ],
            providers: [
                __WEBPACK_IMPORTED_MODULE_5__shared_dataService__["a" /* DataService */]
            ],
            bootstrap: [__WEBPACK_IMPORTED_MODULE_3__app_component__["a" /* AppComponent */]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "../../../../../ClientApp/app/shared/dataService.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_common_http__ = __webpack_require__("../../../common/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_rxjs_add_operator_map__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/map.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var DataService = (function () {
    function DataService(http) {
        this.http = http;
        this.albums = [];
    }
    DataService.prototype.loadAlbums = function () {
        var _this = this;
        return this.http.get("/api/album/get")
            .map(function (data) {
            _this.albums = data;
            return true;
        });
    };
    DataService.prototype.createAlbum = function (albumName) {
        var params = new URLSearchParams();
        params.append("albumName", albumName);
        this.http.post("/api/album/create", params)
            .subscribe(function (data) {
            alert("Album created!");
            return true;
        }, function (error) {
            console.log("error");
        });
    };
    DataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["w" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_0__angular_common_http__["a" /* HttpClient */]])
    ], DataService);
    return DataService;
}());



/***/ }),

/***/ "../../../../../ClientApp/environments/environment.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return environment; });
// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.
var environment = {
    production: false
};


/***/ }),

/***/ "../../../../../ClientApp/main.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_platform_browser_dynamic__ = __webpack_require__("../../../platform-browser-dynamic/esm5/platform-browser-dynamic.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__app_app_module__ = __webpack_require__("../../../../../ClientApp/app/app.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__environments_environment__ = __webpack_require__("../../../../../ClientApp/environments/environment.ts");




if (__WEBPACK_IMPORTED_MODULE_3__environments_environment__["a" /* environment */].production) {
    Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["_5" /* enableProdMode */])();
}
Object(__WEBPACK_IMPORTED_MODULE_1__angular_platform_browser_dynamic__["a" /* platformBrowserDynamic */])().bootstrapModule(__WEBPACK_IMPORTED_MODULE_2__app_app_module__["a" /* AppModule */])
    .catch(function (err) { return console.log(err); });


/***/ }),

/***/ 0:
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__("../../../../../ClientApp/main.ts");


/***/ })

},[0]);
//# sourceMappingURL=main.bundle.js.map