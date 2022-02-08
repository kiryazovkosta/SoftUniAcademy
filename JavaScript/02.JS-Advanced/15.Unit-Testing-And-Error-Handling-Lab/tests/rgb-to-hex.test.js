const expect =require("chai").expect;
const rgbToHexColor = require('../src/06.rgb-to-hex');

describe("Check for RgbToHex Tests", () => {
    it('Returns valid hex value as string for correct rgb', () => {
        expect(rgbToHexColor(0, 0, 0)).to.be.equal('#000000');
        expect(rgbToHexColor(255, 255, 255)).to.be.equal('#FFFFFF');
        expect(rgbToHexColor(23, 45, 67)).to.be.equal('#172D43');
    });
    it('Returns undefined when red value is invalid', () => {
        expect(rgbToHexColor('a', 0, 0)).to.be.undefined;
        expect(rgbToHexColor(-1, 255, 255)).to.be.undefined;
        expect(rgbToHexColor(256, 45, 67)).to.be.undefined;
    });
    it('Returns undefined when green value is invalid', () => {
        expect(rgbToHexColor(255, 'a', 255)).to.be.undefined;
        expect(rgbToHexColor(255, -5, 255)).to.be.undefined;
        expect(rgbToHexColor(255, 256, 255)).to.be.undefined;
    });
    it('Returns undefined when blue value is invalid', () => {
        expect(rgbToHexColor(255, 255, {blue: 2})).to.be.undefined;
        expect(rgbToHexColor(255, 255, -5)).to.be.undefined;
        expect(rgbToHexColor(255, 255, 256)).to.be.undefined;
    });
});