using Dapper;
using System.Data.SqlClient;

namespace Empleados.Server.Db
{
    public class Conexion
    {
        //por medio de appsettings y para hacerla generica se realiza un contructor en el program para pasar la conexion
        public Conexion(string connectionString) => ConnectionString = connectionString;
        public static string? ConnectionString { get; set; }

        public static SqlConnection DbContextSQLOperacion()
        {
            return new SqlConnection(ConnectionString);
        }

        //methods 
        #region Gets

        //get all

        public static async Task<IEnumerable<T>> GetAll<T>(string sql)
        {
            return await DbContextSQLOperacion().QueryAsync<T>(sql);
        }

        //Get with param

        public static async Task<T> GetById<T>(string sql)
        {
            return await DbContextSQLOperacion().QueryFirstOrDefaultAsync<T>(sql);
        }
        #endregion

        #region Insert/Update/delete

        public static async Task<bool> InsertUpdateParam<T>(string sql, T model)
        {
            try
            {
                return await DbContextSQLOperacion().ExecuteAsync(sql, model) > 0;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public static async Task<bool> InsertUpdate(string sql)
        {
            try
            {
                return await DbContextSQLOperacion().ExecuteAsync(sql) > 0;

            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion
    }
}
