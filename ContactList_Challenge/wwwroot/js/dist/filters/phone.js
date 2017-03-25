'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});
var phone = exports.phone = function phone() {
    return function (number) {
        number = ('' + number).replace(/\D/g, '');
        if (isNaN(+number) || !number.length) return number;

        if (number.length !== 7 && number.length !== 10 && number.length < 11) {
            return number;
        }

        var match = void 0;
        var phone = void 0;
        switch (number.length) {
            case 7:
                match = number.match(/^(\d{3})(\d{4})$/);
                phone = !match ? number : match[1] + '-' + match[2];
                break;
            case 10:
                match = number.match(/^(\d{3})(\d{3})(\d{4})$/);
                phone = !match ? number : '(' + match[1] + ') ' + match[2] + '-' + match[3];
                break;
            default:
                match = number.match(/^(\d{1,9})(\d{3})(\d{3})(\d{4})$/);
                phone = !match ? number : match[1] + '(' + match[2] + ') ' + match[3] + '-' + match[4];
        }

        return phone;
    };
};
//# sourceMappingURL=phone.js.map
