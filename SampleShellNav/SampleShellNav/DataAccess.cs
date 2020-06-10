using SampleShellNav.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace SampleShellNav
{
    public class DataAccess
    {
        private SQLiteConnection conn;
        public DataAccess()
        {
            string dbName = "MyDb.db3";
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, dbName);
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Employee>();
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return conn.Query<Employee>("select * from Employee order by EmpName");
            //return conn.Table<Employee>().ToList();
        }

        public int InsertEmployee(Employee employee)
        {
            try
            {
                return conn.Insert(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int DeleteEmployee(Employee employee)
        {
            try
            {
                return conn.Delete(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int EditEmployee(Employee employee)
        {
            try
            {
                return conn.Update(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
