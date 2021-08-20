"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var artist_service_1 = require("./artist.service");
describe('ArtistService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(artist_service_1.ArtistService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=artist.service.spec.js.map