using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
namespace DataBase;

public class DBSqlServer<T>
    where T : DataBaseObject, new()
{
    private SqlConnection conn;

    public DBSqlServer(string dataSource, string database)
    {
        SqlConnectionStringBuilder s = new();
        s.DataSource = dataSource;
        s.InitialCatalog = database;
        s.IntegratedSecurity = true;
        s.TrustServerCertificate = true; 
        string connection = s.ConnectionString;
        conn = new SqlConnection(connection);
    }

    public List<T> All
    {
        get
        {
            List<T> values = [];
            conn.Open();
            SqlCommand cmd = new($"SELECT * FROM {typeof(T).Name}");
            cmd.Connection = conn;
            var reader = cmd.ExecuteReader();

            DataTable dt = new();
            dt.Load(reader);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                T obj = new();
                obj.LoadFromSqlRow(dt.Rows[i]);
                values.Add(obj);
            }

            conn.Close();   
            return values;
        }
    }

    public void Save(T obj)
    {
        string values = obj.SaveToSql();
        SqlCommand cmd = new(values)
        {
            Connection = conn
        };
        cmd.ExecuteNonQuery();
        conn.Close();
    }
}