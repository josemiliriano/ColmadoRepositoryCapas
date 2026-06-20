using Domain.Entities;
using Infraestructure.Data;
using Infraestructure.Eceptions;
using Infraestructure.Product.DTOs;
using Infraestructure.Provider.DTOs;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Provider
{
    public class ProviderAppService : IProviderAppService
    {
        private readonly GeneralRepository<CDProvider> _serviceProvider;        
        public ProviderAppService(GeneralRepository<CDProvider> serviceProvider)
        {
            _serviceProvider = serviceProvider;            
        }
        public CDProvider addProvider(ProviderDto provider)
        {
            var exist = _serviceProvider.Exists(p => p.ProviderName.ToLower() == provider.ProviderName.ToLower());
            if (exist)
            {
                throw new AlreadyExistsException("Proveedor",provider.ProviderName);
            }
            var newProvider = new CDProvider
            {
                ProviderName = provider.ProviderName,
                ContactName = provider.ContactName,
                Address = provider.Address,
                City = provider.City,
                Country = provider.Country,
                Phone = provider.Phone
            };
            _serviceProvider.Add(newProvider);
            return newProvider;
        }

        public void DeleteProvider(int id)
        {
            var provider = _serviceProvider.GetById(id);
            if (provider != null)
            {
                _serviceProvider.Delete(provider);
            }
        }

        public List<CDProvider> GetAllProviders()
        {
            return _serviceProvider.GetAll();
        }

        public List<CDProvider> GetAllProviderWihtCondition()
        {
            return _serviceProvider.GetAll().Where(p => p.IsDelete == '0').ToList();            

        }

        public CDProvider GetById(int id)
        {
            return _serviceProvider.GetById(id);
        }

        public bool SoftDelete(int id)
        {
            var Provider = _serviceProvider.GetById(id);
            if (Provider != null)
            {
                Provider.IsDelete = '1';
            }
            return _serviceProvider.SoftDelete(Provider);
        }

        public CDProvider UpdatePrvider(int id, ProviderDto provider)
        {
            var Provider = _serviceProvider.GetById(id);
            if (Provider != null)
            {
                Provider.ProviderName = provider.ProviderName;
                Provider.ContactName = provider.ContactName;
                Provider.Address = provider.Address;
                Provider.City = provider.City;
                Provider.Country = provider.Country;
                Provider.Phone = provider.Phone;
            }
            _serviceProvider.Update(Provider);
            return Provider;
        }
    }
}
