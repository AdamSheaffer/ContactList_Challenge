'use strict';

var _appComponent = require('./components/app/app.component.js');

var _contactFormComponent = require('./components/contactForm/contactForm.component.js');

var _contactsService = require('./services/contactsService.js');

var _phone = require('./filters/phone.js');

// Services
// Components
angular.module('contactList', ['ngMaterial']).component('contactListApp', _appComponent.appComponent).component('contactForm', _contactFormComponent.contactForm).service('contactService', _contactsService.contactService).filter('phone', _phone.phone);

// Filters


angular.bootstrap(document, ['contactList']);
//# sourceMappingURL=app.js.map
