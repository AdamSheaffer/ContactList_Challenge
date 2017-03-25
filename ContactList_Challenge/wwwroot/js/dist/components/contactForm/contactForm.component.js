'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});
exports.contactForm = undefined;

var _constants = require('../../constants.js');

var controller = function controller(contactService, $mdToast) {
    var vm = this;

    vm.contacts = [];
    vm.contact = Object.create(null);
    vm.contactBeingEdited = null;

    vm.$onInit = function () {
        contactService.getContacts().then(function (res) {
            vm.contacts = res.data;
        }, function (err) {
            console.log(err);
        });
    };

    vm.submitContact = function () {
        contactService.postContact(vm.contact).then(function (res) {
            var contact = res.data;
            addOrUpdateContact(contact);
            $mdToast.showSimple(contact.firstName + ' added to your contacts');
            vm.resetContact();
        }, function (err) {
            $mdToast.showSimple(err.data.message);
        });
    };

    vm.selectForEdit = function (contact) {
        vm.contact = Object.assign({}, contact);
        vm.contactBeingEdited = contact;
    };

    vm.deleteContact = function (contact) {
        contactService.deleteContact(contact).then(function (res) {
            var contact = res.data;
            removeContact(contact);
            $mdToast.showSimple(contact.firstName + ' removed from your contacts');
        }, function (err) {
            $mdToast.showSimple(err.data.message);
        });
    };

    vm.resetContact = function () {
        vm.contact = Object.create(null);
        vm.contactBeingEdited = null;
    };

    function removeContact(contact) {
        var index = vm.contacts.findIndex(function (c) {
            return c.id === contact.id;
        });

        if (index > -1) vm.contacts.splice(index, 1);
    }

    function addOrUpdateContact(contact) {
        var index = vm.contacts.findIndex(function (c) {
            return c.id === contact.id;
        });

        if (index > -1) {
            vm.contacts[index] = contact;
        } else {
            vm.contacts.push(contact);
        }
    }
};

var contactForm = exports.contactForm = {
    templateUrl: _constants.constants.COMPONENTS_URL + 'contactForm/contact-form-component.html',
    controller: controller,
    controllerAs: 'vm'
};
//# sourceMappingURL=contactForm.component.js.map
