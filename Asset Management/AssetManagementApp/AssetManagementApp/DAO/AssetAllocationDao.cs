using AssetManagementApp.Entity;
using AssetManagementApp.Util;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagementApp.DAO
{
    public class AssetAllocationDAO : IAssetAllocationDao<AssetAllocation>
    {
        SqlConnection sqlCon = DBConnUtil.GetConnection("appSettings.json");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public AssetAllocation AllocateAsset(AssetAllocation allocation)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("INSERT INTO asset_allocation (asset_id, employee_id, allocation_date, return_date) ");
                queryBuilder.Append("VALUES (@asset_id, @employee_id, @allocation_date, @return_date)");
                cmd.CommandText = queryBuilder.ToString();

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@asset_id", allocation.asset_id);
                cmd.Parameters.AddWithValue("@employee_id", allocation.employee_id);
                cmd.Parameters.AddWithValue("@allocation_date", allocation.allocation_date);
                cmd.Parameters.AddWithValue("@return_date", allocation.return_date);

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                cmd.ExecuteNonQuery();
                return allocation;
            }
            catch (SqlException)
            {
                return null;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        //public bool DeallocateAsset(int allocation_id)
        //{
        //    throw new NotImplementedException();
        //}

        public bool DeleteAllocation(int allocation_id)
        {
            try
            {
                cmd.Connection = sqlCon;
                cmd.CommandText = $"DELETE FROM asset_allocation WHERE allocation_id = {allocation_id}";

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public List<AssetAllocation> GetAllAllocations()
        {
            List<AssetAllocation> allocationList = new List<AssetAllocation>();
            try
            {
                cmd.Connection = sqlCon;
                cmd.CommandText = "SELECT * FROM asset_allocation";

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    AssetAllocation allocation = new AssetAllocation()
                    {
                        allocation_id = Convert.ToInt32(dr["allocation_id"]),
                        asset_id = Convert.ToInt32(dr["asset_id"]),
                        employee_id = Convert.ToInt32(dr["employee_id"]),
                        allocation_date = Convert.ToDateTime(dr["allocation_date"]),
                        return_date = dr["return_date"] != DBNull.Value ? Convert.ToDateTime(dr["return_date"]) : (DateTime?)null
                    };
                    allocationList.Add(allocation);
                }

                dr.Close();
                return allocationList;
            }
            catch
            {
                return null;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public AssetAllocation GetAllocationById(int allocation_id)
        {
            try
            {
                cmd.Connection = sqlCon;
                cmd.CommandText = "SELECT * FROM asset_allocation WHERE allocation_id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", allocation_id);

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    AssetAllocation allocation = new AssetAllocation()
                    {
                        allocation_id = Convert.ToInt32(dr["allocation_id"]),
                        asset_id = Convert.ToInt32(dr["asset_id"]),
                        employee_id = Convert.ToInt32(dr["employee_id"]),
                        allocation_date = Convert.ToDateTime(dr["allocation_date"]),
                        return_date = dr["return_date"] != DBNull.Value ? Convert.ToDateTime(dr["return_date"]) : (DateTime?)null
                    };
                    dr.Close();
                    return allocation;
                }

                dr.Close();
                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public AssetAllocation UpdateAllocation(AssetAllocation allocation)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("UPDATE asset_allocation SET asset_id = @asset_id, employee_id = @employee_id, ");
                queryBuilder.Append("allocation_date = @allocation_date, return_date = @return_date ");
                queryBuilder.Append("WHERE allocation_id = @allocation_id");
                cmd.CommandText = queryBuilder.ToString();

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@asset_id", allocation.asset_id);
                cmd.Parameters.AddWithValue("@employee_id", allocation.employee_id);
                cmd.Parameters.AddWithValue("@allocation_date", allocation.allocation_date);
                cmd.Parameters.AddWithValue("@return_date", allocation.return_date);
                cmd.Parameters.AddWithValue("@allocation_id", allocation.allocation_id);

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                cmd.ExecuteNonQuery();
                return allocation;
            }
            catch (SqlException)
            {
                return null;
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
