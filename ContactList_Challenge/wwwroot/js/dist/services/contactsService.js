'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});
exports.contactService = undefined;

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _constants = require('../constants.js');

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var contactService = exports.contactService = function () {
    function contactService($http) {
        _classCallCheck(this, contactService);

        this.$http = $http;
        this.url = _constants.constants.CONTACTS_API;
    }

    _createClass(contactService, [{
        key: 'getContacts',
        value: function getContacts() {
            return this.$http.get(this.url);
        }
    }, {
        key: 'postContact',
        value: function postContact(contact) {
            return this.$http.post(this.url, contact);
        }
    }, {
        key: 'deleteContact',
        value: function deleteContact(contact) {
            return this.$http.delete(this.url + contact.id);
        }
    }]);

    return contactService;
}();
//# sourceMappingURL=contactsService.js.map
