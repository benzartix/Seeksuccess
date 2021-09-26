using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        public IAccountRepository Account { get; }
        public ICountryRepository Country { get; }
        public ISecteurRepository Secteur { get; }
        void Save();
    }
}
