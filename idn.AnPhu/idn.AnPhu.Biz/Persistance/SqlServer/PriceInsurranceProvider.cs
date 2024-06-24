using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    public class PriceInsurranceProvider : DataAccessBase, IPriceInsurranceProvider
    {
        public PriceInsurrance Get(PriceInsurrance dummy)
        {
            var comm = this.GetCommand("sp_PriceInsurrancesGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "PriceInsurranceId", dummy.PriceInsurranceId);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<PriceInsurrance>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //throw new NotImplementedException();
        }

        public void Add(PriceInsurrance item)
        {
            //var comm = this.GetCommand("sp_PriceInsurrance_Insert");
            //if (comm == null) return;
            //comm.AddParameter<string>(this.Factory, "Url", item.Url);
            //comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            ////comm.AddParameter<DateTime>(this.Factory, "CreateDate", item.CreateDate);
            ////comm.AddParameter<DateTime>(this.Factory, "EditDate", item.EditDate);
            //comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            //comm.AddParameter<string>(this.Factory, "Image", item.Image);
            //comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            //comm.SafeExecuteNonQuery();
            throw new NotImplementedException();
        }

        public void Add(PriceInsurrance item, string culture)
        {
            var comm = this.GetCommand("sp_PriceInsurrance_Insert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "PriceInsurranceName", item.PriceInsurranceName);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<decimal>(this.Factory, "PriceInsurranceValue", item.PriceInsurranceValue);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Update(PriceInsurrance @new, PriceInsurrance old)
        {
            var item = @new;
            item.PriceInsurranceId = old.PriceInsurranceId;
            var comm = this.GetCommand("sp_PriceInsurrance_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "PriceInsurranceId", item.PriceInsurranceId);
            comm.AddParameter<string>(this.Factory, "PriceInsurranceName", item.PriceInsurranceName);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<decimal>(this.Factory, "PriceInsurranceValue", item.PriceInsurranceValue);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(PriceInsurrance item)
        {
            var comm = this.GetCommand("sp_PriceInsurrance_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "PriceInsurranceId", item.PriceInsurranceId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public List<PriceInsurrance> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }


        public List<PriceInsurrance> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_PriceInsurrancesSearch");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "Length", lenght);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var totalItemsParam = comm.AddParameter(this.Factory, "TotalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;
            var dt = this.GetTable(comm);
            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItem = Convert.ToInt32(totalItemsParam.Value);
            }
            return EntityBase.ParseListFromTable<PriceInsurrance>(dt);
        }
        public List<PriceInsurrance> GetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_PriceInsurrancesGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<PriceInsurrance>(dt);
        }
    }
}
