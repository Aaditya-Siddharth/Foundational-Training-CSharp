using AssetManagementApp.Entity;
using AssetManagementApp.Util;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.DAO
{
    public class MaintenanceDAO : IMaintenanceDao<MaintenanceRecord>
    {
        SqlConnection sqlCon = DBConnUtil.GetConnection("appSettings.json");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public MaintenanceRecord AddMaintenanceRecord(MaintenanceRecord maintenance)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("INSERT INTO maintenance (asset_id, maintenance_date, description, cost) VALUES (@asset_id, @maintenance_date, @description, @cost)");
                cmd.CommandText = queryBuilder.ToString();

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@asset_id", maintenance.asset_id);
                cmd.Parameters.AddWithValue("@maintenance_date", maintenance.maintenance_date);
                cmd.Parameters.AddWithValue("@description", maintenance.description);
                cmd.Parameters.AddWithValue("@cost", maintenance.cost);

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                cmd.ExecuteNonQuery();
                return maintenance;
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

        public bool DeleteMaintenanceRecord(int maintenance_id)
        {
            try
            {
                cmd.Connection = sqlCon;
                cmd.CommandText = $"DELETE FROM maintenance WHERE maintenance_id = {maintenance_id}";

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

        public List<MaintenanceRecord> GetAllMaintenanceRecords()
        {
            List<MaintenanceRecord> maintenanceList = new List<MaintenanceRecord>();
            try
            {
                cmd.Connection = sqlCon;
                cmd.CommandText = "SELECT * FROM maintenance";

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    MaintenanceRecord m = new MaintenanceRecord();
                    {
                        m.maintenance_id = Convert.ToInt32(dr["maintenance_id"]);
                        m.asset_id = Convert.ToInt32(dr["asset_id"]);
                        m.maintenance_date = Convert.ToDateTime(dr["maintenance_date"]);
                        m.description = dr["description"].ToString();
                        m.cost = Convert.ToDecimal(dr["maintenance_status"]);
                        maintenanceList.Add(m);

                    }
                }

                dr.Close();
                return maintenanceList;
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

        public MaintenanceRecord GetMaintenanceRecordById(int maintenance_id)
        {
            try
            {
                cmd.Connection = sqlCon;
                cmd.CommandText = "SELECT * FROM maintenance WHERE maintenance_id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", maintenance_id);

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    MaintenanceRecord m = new MaintenanceRecord()
                    {
                        maintenance_id = Convert.ToInt32(dr["maintenance_id"]),
                        asset_id = Convert.ToInt32(dr["asset_id"]),
                        maintenance_date = Convert.ToDateTime(dr["maintenance_date"]),
                        description = dr["description"].ToString(),
                        cost = Convert.ToDecimal(dr["cost"])
                    };
                    dr.Close();
                    return m;
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

        public MaintenanceRecord UpdateMaintenanceRecord(MaintenanceRecord maintenance)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("UPDATE maintenance SET asset_id = @asset_id, maintenance_date = @maintenance_date, ");
                queryBuilder.Append("description = @description, cost = @cost ");
                queryBuilder.Append("WHERE maintenance_id = @maintenance_id");
                cmd.CommandText = queryBuilder.ToString();

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@asset_id", maintenance.asset_id);
                cmd.Parameters.AddWithValue("@maintenance_date", maintenance.maintenance_date);
                cmd.Parameters.AddWithValue("@description", maintenance.description);
                cmd.Parameters.AddWithValue("@cost", maintenance.cost);
                cmd.Parameters.AddWithValue("@maintenance_id", maintenance.maintenance_id);

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                cmd.ExecuteNonQuery();
                return maintenance;
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
