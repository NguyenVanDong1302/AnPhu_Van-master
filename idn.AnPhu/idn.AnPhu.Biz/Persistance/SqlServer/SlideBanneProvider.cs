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
    public class SlideBanneProvider : DataAccessBase, ISlideBannerProvider
    {
        public void Add(SlideBanner model, string culture)
        {
            throw new NotImplementedException();
        }

        public void Add(SlideBanner item)
        {
            throw new NotImplementedException();
        }

        public SlideBanner Get(SlideBanner dummy)
        {
            throw new NotImplementedException();
        }

        public List<SlideBanner> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public void Remove(SlideBanner item)
        {
            throw new NotImplementedException();
        }

        public List<SlideBanner> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            throw new NotImplementedException();
        }

        public List<SlideBanner> SelectTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_SlideBanner_SelectTop");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<SlideBanner>(dt);
        }

        public void Update(SlideBanner @new, SlideBanner old)
        {
            throw new NotImplementedException();
        }
    }
}
