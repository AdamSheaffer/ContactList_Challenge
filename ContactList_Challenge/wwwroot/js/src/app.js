import 'angular-material';

// Components
import { appComponent } from './components/app/app.component.js';
import { contactForm } from './components/contactForm/contactForm.component.js';

// Services
import { contactService } from './services/contactsService.js';

// Filters
import { phone } from './filters/phone.js';

angular.module('contactList', ['ngMaterial'])
    .component('contactListApp', appComponent)
    .component('contactForm', contactForm)
    .service('contactService', contactService)
    .filter('phone', phone);

angular.bootstrap(document, ['contactList']);