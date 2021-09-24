using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        public IAccountRepository Account { get; set;}
        public ICountryRepository Country { get; set; }
        public ISecteurRepository Secteur { get; set; }
        void Save();
    }
}
