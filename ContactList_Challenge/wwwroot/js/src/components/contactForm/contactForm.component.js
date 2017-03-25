import { constants } from '../../constants.js';

const controller = function(contactService, $mdToast) {
    const vm = this;

    vm.contacts = [];
    vm.contact = Object.create(null);
    vm.contactBeingEdited = null;
        
    vm.$onInit = function() {
        contactService.getContacts()
            .then((res) => {
                vm.contacts = res.data
            }, (err) => {
                console.log(err);
            });
    }

    vm.submitContact = function() {
        contactService.postContact(vm.contact)
            .then((res) => {
                const contact = res.data
                addOrUpdateContact(contact);
                $mdToast.showSimple(`${contact.firstName} added to your contacts`);
                vm.resetContact();
            }, (err) => {
                $mdToast.showSimple(err.data.message);
            });
    }

    vm.selectForEdit = function(contact) {
        vm.contact = Object.assign({}, contact);
        vm.contactBeingEdited = contact;
    }

    vm.deleteContact = function(contact) {
        contactService.deleteContact(contact)
            .then((res) => {
                const contact = res.data;
                removeContact(contact);
                $mdToast.showSimple(`${contact.firstName} removed from your contacts`)
            }, (err) => {
                $mdToast.showSimple(err.data.message);
            });
    }

    vm.resetContact = function() {
        vm.contact = Object.create(null);
        vm.contactBeingEdited = null;
    }

    function removeContact(contact) {
        const index = vm.contacts.findIndex((c) => c.id === contact.id);

        if (index > -1) vm.contacts.splice(index, 1);
    }

    function addOrUpdateContact(contact) {
        const index = vm.contacts.findIndex((c) => c.id === contact.id);

        if (index > -1) {
            vm.contacts[index] = contact;
        } else {
            vm.contacts.push(contact);
        }
    }
}

export const contactForm = {
    templateUrl: constants.COMPONENTS_URL + 'contactForm/contact-form-component.html',
    controller: controller,
    controllerAs: 'vm'
};