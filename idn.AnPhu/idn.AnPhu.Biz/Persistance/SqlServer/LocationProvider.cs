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
    public class LocationProvider : DataAccessBase, ILocationProvider
    {
        public List<Location> GetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_LocationsGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Location>(dt);
        }
        public Location Get(Location dummy)
        {
            var comm = this.GetCommand("sp_LocationsGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "LocationCode", dummy.LocationCode);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<Location>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //throw new NotImplementedException();
        }

        public void Add(Location item)
        {
            //var comm = this.GetCommand("sp_Location_Insert");
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

        public void Add(Location item, string culture)
        {
            //var comm = this.GetCommand("sp_Location_Insert");
            //if (comm == null) return;
            //comm.AddParameter<string>(this.Factory, "LocationName", item.LocationName);
            //comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            //comm.AddParameter<string>(this.Factory, "Culture", culture);
            //comm.AddParameter<decimal>(this.Factory, "LocationValue", item.LocationValue);
            //comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            //comm.AddParameter<int>(this.Factory, "LocationValue", item.LocationValue);
            //comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            //comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Update(Location @new, Location old)
        {
            //var item = @new;
            //item.LocationId = old.LocationId;
            //var comm = this.GetCommand("sp_Location_Update");
            //if (comm == null) return;
            //comm.AddParameter<int>(this.Factory, "LocationId", item.LocationId);
            //comm.AddParameter<string>(this.Factory, "LocationName", item.LocationName);
            //comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            //comm.AddParameter<int>(this.Factory, "LocationValue", item.LocationValue);
            //comm.AddParameter<decimal>(this.Factory, "LocationValue", item.LocationValue);
            //comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            //comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(Location item)
        {
            //var comm = this.GetCommand("sp_Location_Delete");
            //if (comm == null) return;
            //comm.AddParameter<int>(this.Factory, "LocationId", item.LocationId);
            //comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public List<Location> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }


        public List<Location> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_LocationsSearch");
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
            return EntityBase.ParseListFromTable<Location>(dt);
        }

    }
}
