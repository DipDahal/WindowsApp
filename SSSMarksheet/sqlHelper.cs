using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for sqlHelper
/// </summary>
public class sqlHelper
{
    public SqlConnection cn;
    public SqlDataAdapter da;
    public SqlCommand cm;
    public DataSet ds = new DataSet();
    public SqlDataReader myreader;
    public DataTable dt = new DataTable();
    public sqlHelper()
    {
        cn = new SqlConnection(@"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True");
    }
    public int dmlstmt(string s)
    {
        try
        {
            cm = new SqlCommand(s, cn);
            cm.ExecuteNonQuery();
            return 1;
        }
        catch
        {
            return 0;
        }
    }
    public int fill(string s)
    {
        try
        {
            cm = new SqlCommand(s, cn);
            myreader = cm.ExecuteReader();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    internal void fetch(string v1, string v2)
    {
        throw new NotImplementedException();
    }

    public DataSet fetch(string s)
    {
        da = new SqlDataAdapter(s, cn);

        ds.Clear();
        ds.Reset();
        da.Fill(ds);
        return ds;
    }
    public DataTable datagridFetch(string s)
    {
        da = new SqlDataAdapter(s, cn);

        ds.Clear();
        ds.Reset();
        da.Fill(ds);

        dt = ds.Tables[0];
        return dt;
    }

}



