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
    public class EmployeeDAO : IEmployeeDao<Employees>
    {
        SqlConnection sqlCon = DBConnUtil.GetConnection("appSettings.json");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public Employees AddEmployee(Employees employee)
        {
            try
            {
                cmd.Connection = sqlCon;

                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("INSERT INTO employees (name, department, email, password) ");
                queryBuilder.Append("VALUES (@name, @department, @email, @password); ");
                queryBuilder.Append("SELECT CAST(SCOPE_IDENTITY() as int);"); // Return the new ID

                cmd.CommandText = queryBuilder.ToString();
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@name", employee.name);
                cmd.Parameters.AddWithValue("@department", employee.department);
                cmd.Parameters.AddWithValue("@email", employee.email);
                cmd.Parameters.AddWithValue("@password", employee.password);

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                // This gets the new employee_id
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    employee.employee_Id = Convert.ToInt32(result);
                    return employee;
                }

                return null;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("AddEmployee SQL Error: " + ex.Message);  // Useful during debugging
                return null;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        //public Employees AddEmployee(Employees employee)
        //{
        //    try
        //    {
        //        cmd.Connection = sqlCon;
        //        StringBuilder queryBuilder = new StringBuilder();
        //        queryBuilder.Append("INSERT INTO employees (name, department, email, password)  VALUES (@name, @department, @email, @password)");
        //        cmd.CommandText = queryBuilder.ToString();

        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@name", employee.name);
        //        cmd.Parameters.AddWithValue("@department", employee.department);
        //        cmd.Parameters.AddWithValue("@email", employee.email);
        //        cmd.Parameters.AddWithValue("@password", employee.password);

        //        if (sqlCon.State == System.Data.ConnectionState.Closed)
        //        {
        //            sqlCon.Open();
        //        }

        //        cmd.ExecuteNonQuery(); // Insert operation does not return any data, so it is not a Query to execute
        //        return employee;
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("SQL Error in AddEmployee: " + ex.Message);
        //        return null;
        //    }

        //    finally
        //    {
        //        sqlCon.Close();
        //    }
        //}

        public bool DeleteEmployee(int employee_id)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder = queryBuilder.Append($"DELETE FROM employees WHERE employee_id = {employee_id}");
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
            finally
            {
                sqlCon.Close();
            }
        }

        public List<Employees> GetAllEmployees()
        {

            List<Employees> empList = new List<Employees>();
            try
            {
                cmd.Connection = sqlCon;
                cmd.CommandText = "SELECT * FROM employees";

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Employees emp = new Employees()
                    {
                        employee_Id = Convert.ToInt32(dr["employee_id"]),
                        name = dr["name"].ToString(),
                        department = dr["department"].ToString(),
                        email = dr["email"].ToString(),
                        password = dr["password"].ToString()
                    };
                    empList.Add(emp);
                }
                dr.Close();
                return empList;
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

        public Employees GetEmployeeById(int employee_id)
        {
            try
            {
                cmd.Connection = sqlCon;
                cmd.CommandText = "SELECT * FROM employees WHERE employee_id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", employee_id);

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Employees emp = new Employees();
                    {
                        

                        emp.employee_id = Convert.ToInt32(dr["employee_id"]);
                        emp.name = Convert.ToString(dr["name"]);
                        emp.department = Convert.ToString(dr["department"]);
                        emp.email = Convert.ToString(dr["email"]);
                        emp.password = Convert.ToString(dr["password"]);
                    };
                    dr.Close();
                    return emp;
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

        //public Employees UpdateEmployee(Employees employee)
        //{
        //    try
        //    {
        //        cmd.Connection = sqlCon;
        //        StringBuilder queryBuilder = new StringBuilder();
        //        queryBuilder.Append($"UPDATE employees SET name = @name, department = @department, email = @email, password = @password WHERE employee_id = @id");
        //        queryBuilder.Append($"UPDATE employees SET name = '{employee.name}', department = '{employee.department}', email = '{employee.email}', password = '{employee.password}' WHERE employee_id = {employee.employee_id}");
        //        cmd.CommandText = queryBuilder.ToString();

        //        if (sqlCon.State == System.Data.ConnectionState.Closed)
        //        {
        //            sqlCon.Open();
        //        }
        //        cmd.ExecuteNonQuery();
        //        return employee;
        //    }
        //    catch (SqlException ex)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        sqlCon.Close();
        //    }
        //}

        public Employees UpdateEmployee(Employees employee)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("UPDATE employees ");
                queryBuilder.Append("SET name = @name, department = @department, email = @email, password = @password ");
                queryBuilder.Append("WHERE employee_id = @id");

                cmd.CommandText = queryBuilder.ToString();
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@name", employee.name);
                cmd.Parameters.AddWithValue("@department", employee.department);
                cmd.Parameters.AddWithValue("@email", employee.email);
                cmd.Parameters.AddWithValue("@password", employee.password);
                cmd.Parameters.AddWithValue("@id", employee.employee_Id);

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    return employee;
                else
                    return null;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("UpdateEmployee SQL Error: " + ex.Message);
                return null;
            }
            finally
            {
                sqlCon.Close();
            }
        }

    }
}
