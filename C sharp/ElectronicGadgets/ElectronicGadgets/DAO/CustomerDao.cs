using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TechShopApp.Entities;
using TechShopApp.Exceptions;
using TechShopApp.Util;

namespace TechShopApp.DAO
{
    public class CustomerDao:ICustomersDao<Customers>
    {
        SqlConnection sqlCon = DBConnUtil.GetConnection("appSettings.json");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public bool DeleteCustomerInfo(int CustomerID)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder = queryBuilder.Append($"delete from Customers where CustomerID = {CustomerID}");
                cmd.CommandText = queryBuilder.ToString();

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        public List<Customers> GetAllCustomerInfo()
        {
            List<Customers> customersList = new List<Customers>();
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder = queryBuilder.Append($" Select * from Customers");
                cmd.CommandText = queryBuilder.ToString();

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open(); 
                }
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    { 
                        Customers customers = new Customers();
                        customers.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                        customers.FirstName = Convert.ToString(dr["FirstName"]);
                        customers.LastName = Convert.ToString(dr["LastName"]);
                        customers.Email = Convert.ToString(dr["Email"]);
                        customers.Phone = Convert.ToString(dr["Phone"]);
                        customers.Address = Convert.ToString(dr["Address"]);

                        customersList.Add(customers);   
                    }
                    dr.Close();
                    return customersList;
                }
                else
                {
                    return null;

                }

            }
            catch (SqlException ex)
            {
                return customersList;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public Customers GetCustomerInfoByID(int CustomerID)
        {
            Customers customers = new Customers();
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder = queryBuilder.Append($" Select * from Customers where CustomerID='{CustomerID}'");
                cmd.CommandText = queryBuilder.ToString();

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        customers.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                        customers.FirstName = Convert.ToString(dr["FirstName"]);
                        customers.LastName = Convert.ToString(dr["LastName"]);
                        customers.Email = Convert.ToString(dr["Email"]);
                        customers.Phone = Convert.ToString(dr["Phone"].ToString);
                        customers.Address = Convert.ToString(dr["Address"].ToString);
                    }
                    dr.Close();
                    return customers;
                }
                else
                {
                    return null;

                }

            }
            catch (SqlException ex)
            {
                return null;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public Customers SaveCustomerInfo(Customers Customers)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                //queryBuilder = queryBuilder.Append($"Insert Into Customers values('{Customers.FirstName}','{Customers.LastName}','{Customers.Email}','{Customers.Phone}','{Customers.Address}')");
                queryBuilder = queryBuilder.Append($"INSERT INTO Customers(FirstName, LastName, Email, Phone, Address) VALUES(@FirstName, @LastName, @Email, @Phone, @Address)");
                cmd.CommandText = queryBuilder.ToString();
                cmd.Parameters.AddWithValue("@FirstName", Customers.FirstName);
                cmd.Parameters.AddWithValue("@LastName", Customers.LastName);
                cmd.Parameters.AddWithValue("@Email", Customers.Email);
                cmd.Parameters.AddWithValue("@Phone",Customers.Phone);
                cmd.Parameters.AddWithValue("@Address", Customers.Address);

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                cmd.ExecuteNonQuery();
                return Customers;

            }
            catch(SqlException ex)
            {
                return null;
            }
            catch (InvalidCustomerIDException ex)
            {
                return null;
            }
        }

        public Customers UpdateCustomerInfo(Customers Customers)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder = queryBuilder.Append($" update Customers set FirstName = '{Customers.FirstName}', LastName = '{Customers.LastName}', Email='{Customers.Email}', Phone'{Customers.Phone}',Address'{Customers.Address}' where CustomerID='{Customers.CustomerID}'");
                cmd.CommandText = queryBuilder.ToString();

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                cmd.ExecuteNonQuery();
                return Customers;
            }
            catch (SqlException ex)
            {
                return null;
            }
            catch (InvalidCustomerIDException ex)
            {
                return null;

            }
        }
    }
    
}
