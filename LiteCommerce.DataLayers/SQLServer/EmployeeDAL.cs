using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers.SQLServer
{
    /// <summary>
    /// Cài đặt các tính năng xử lý dữ liệu nhân viên trong CSDL SQL Server
    /// </summary>
    public class EmployeeDAL : IEmployeeDAL
    {
        private string connectionString;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public EmployeeDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int Add(Employee data)
        {
            throw new NotImplementedException();
        }

        public int Count(string searchValue)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int supplierID)
        {
            throw new NotImplementedException();
        }

        public Employee Get(int supplierID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Employee> List()
        {
            List<Employee> data = new List<Employee>();
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = this.connectionString;
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Employees";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;


                using (SqlDataReader dbReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (dbReader.Read())
                    {
                        data.Add(new Employee()
                        {
                            EmployeeID = Convert.ToInt32(dbReader["EmployeeID"]),
                            FirtsName = Convert.ToString(dbReader["FirstName"]),
                            LastName = Convert.ToString(dbReader["LastName"]),
                            BirthDate = Convert.ToDateTime(dbReader["BirthDate"]),
                            Photo = Convert.ToString(dbReader["Photo"]),
                            Notes = Convert.ToString(dbReader["Notes"]),
                            Email = Convert.ToString(dbReader["Email"]),
                            Password = Convert.ToString(dbReader["Password"]),
                        });
                    }
                }


                cn.Close();
            }

            return data;
        }

        public List<Employee> List(int page, int pageSize, string searchValue)
        {
            throw new NotImplementedException();
        }

        public bool Update(Employee data)
        {
            throw new NotImplementedException();
        }
    }
}
