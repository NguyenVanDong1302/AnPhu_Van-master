using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    //internal class AppDicDomainProvider
    //{
    //}

    public class AppDicDomainProvider : DataAccessBase, IAppDicDomainProvider 
    {
        public void Add(AppDicDomain item)
        {
            throw new NotImplementedException();
        }

        public AppDicDomain Get(AppDicDomain dummy)
        {
            var comm = this.GetCommand("sp_App_DomainGet_ItemCode_DomainCode");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Domain_Code", dummy.Domain_Code);
            comm.AddParameter<string>(this.Factory, "Item_Code", dummy.Item_Code);
            var dt = this.GetTable(comm);
            var appDicDomain = EntityBase.ParseListFromTable<AppDicDomain>(dt).FirstOrDefault();
            return appDicDomain ?? null;
            //throw new NotImplementedException();
        }

        public List<AppDicDomain> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<AppDicDomain> GetListAppDicDomainByItemCode(string domainCode)
        {
            var comm = this.GetCommand("App_Domain_GetDic");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Domain_Code", domainCode);
            var dt = this.GetTable(comm);

            return EntityBase.ParseListFromTable<AppDicDomain>(dt);
        }

        public AppDicDomain GetNewsTypeOnHome(string itemCode)
        {
            throw new NotImplementedException();
        }

        public AppDicDomain GetNewsTypeOnHomeIsActive(string domainCode)
        {
            throw new NotImplementedException();
        }

        public void Remove(AppDicDomain item)
        {
            throw new NotImplementedException();
        }

        public List<AppDicDomain> ShowListNewsOnHome()
        {
            throw new NotImplementedException();
        }

        public void Update(AppDicDomain @new, AppDicDomain old)
        {
            throw new NotImplementedException();
        }

        public void UpdateGetNewsTypeOnHome(string domainCode, string itemCode)
        {
            throw new NotImplementedException();
        }
    }
}
