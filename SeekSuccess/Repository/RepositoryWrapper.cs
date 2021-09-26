using Contracts;
using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;

        private IAccountRepository _account;
        private ICountryRepository _country;
        private ISecteurRepository _secteur;


        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_repoContext);
                }
                return _account;
            }
        }

        public ICountryRepository Country
        {
            get
            {
                if (_country == null)
                {
                    _country = new CountryRepository(_repoContext);
                }
                return _country;
            }
        }

        public ISecteurRepository Secteur
        {
            get
            {
                if (_secteur == null)
                {
                    _secteur = new SecteurRepository(_repoContext);
                }
                return _secteur;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
