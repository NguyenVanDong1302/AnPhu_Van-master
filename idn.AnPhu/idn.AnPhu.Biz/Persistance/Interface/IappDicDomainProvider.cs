using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    //internal class IappDicDomainProvider
    //{
    //}

    public interface IAppDicDomainProvider : IDataProvider<AppDicDomain>
    {
        List<AppDicDomain> GetListAppDicDomainByItemCode(string itemCode);
        List<AppDicDomain> ShowListNewsOnHome();
        AppDicDomain GetNewsTypeOnHome(string itemCode);
        void UpdateGetNewsTypeOnHome(string domainCode, string itemCode);
        AppDicDomain GetNewsTypeOnHomeIsActive(string domainCode);
    }
}
