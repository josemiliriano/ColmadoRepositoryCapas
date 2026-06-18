using Domain.Entities;
using Infraestructure.Provider.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Provider
{
    public interface IProviderAppService
    {
        public CDProvider addProvider(ProviderDto provider);
        public List<CDProvider> GetAllProviders();
        public CDProvider GetById(int id);
        public CDProvider UpdatePrvider(int id, ProviderDto provider);
        public void DeleteProvider(int id);
        public bool SoftDelete(int id);
        public List<CDProvider> GetAllProviderWihtCondition();
    }
}
