import { constants } from '../constants.js';

export class contactService {
    constructor($http) {
        this.$http = $http;
        this.url = constants.CONTACTS_API;
    }

    getContacts() {
        return this.$http.get(this.url);
    }

    postContact(contact) {
        return this.$http.post(this.url, contact);
    }

    deleteContact(contact) {
        return this.$http.delete(this.url + contact.id)
    }
}