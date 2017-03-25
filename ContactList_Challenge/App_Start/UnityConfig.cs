using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using ContactList_Challenge.Interfaces;
using ContactList_Challenge.Repository;
using ContactList_Challenge.Data;
using ContactList_Challenge.Service;

namespace ContactList_Challenge
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IContactsDb, ContactsDb>();
            container.RegisterType<IContactRepository, ContactRepository>();
            container.RegisterType<IPhoneNumberService, PhoneNumberService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}