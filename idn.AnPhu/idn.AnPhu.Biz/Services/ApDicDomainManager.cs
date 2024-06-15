using Client.Core.Data;
using System;
using System.Collections.Generic;
using idn.AnPhu.Biz.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using idn.AnPhu.Biz.Persistance.Interface;

namespace idn.AnPhu.Biz.Services
{
    //internal class ApDicDomainManager
    //{
    //}

    public class AppDicDomainManager : DataManagerBase<AppDicDomain>
    {
        public AppDicDomainManager()
            : base()
        {
        }

        public AppDicDomainManager(IDataProvider<AppDicDomain> provider)
            : base(provider)
        {
        }

        private IAppDicDomainProvider AppDicDomainProvider
        {
            get { return (IAppDicDomainProvider)Provider; }
        }

        public List<AppDicDomain> GetListAppDicDomainByItemCode(string domainCode)
        {
            return AppDicDomainProvider.GetListAppDicDomainByItemCode(domainCode);
        }

        public List<AppDicDomain> ShowListNewsOnHome()
        {
            return AppDicDomainProvider.ShowListNewsOnHome();
        }

        public AppDicDomain GetNewsTypeOnHome(string itemCode)
        {
            return AppDicDomainProvider.GetNewsTypeOnHome(itemCode);
        }

        public void UpdateGetNewsTypeOnHome(string domainCode, string itemCode)
        {
            AppDicDomainProvider.UpdateGetNewsTypeOnHome(domainCode, itemCode);
        }

        public AppDicDomain GetNewsTypeOnHomeIsActive(string domainCode)
        {
            return AppDicDomainProvider.GetNewsTypeOnHomeIsActive(domainCode);
        }
    }
}
