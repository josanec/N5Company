using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using N5Company.Models;

namespace N5Company
{
    public class PermissionTypesDTO
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        string strConnectionString = "";

        public bool Insert(PermissionTypes tipo)
        {
            con.ConnectionString = strConnectionString;
            cmd.CommandText = "insert into PermissionTypes (ID, Description) values (" + tipo.ID + ",'" + tipo.Description + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            if (con.State != ConnectionState.Open)
                con.Open();

            int reg = cmd.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

            if (reg != 0)
                return true;
            else
                return false;


        }

        public bool Update(PermissionTypes tipo)
        {
            con.ConnectionString = strConnectionString;
            cmd.CommandText = "update PermissionTypes set Description = '" + tipo.Description + "' where ID = " + tipo.ID + ")";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            if (con.State != ConnectionState.Open)
                con.Open();

            int reg = cmd.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

            if (reg != 0)
                return true;
            else
                return false;
        }

        public bool Delete(int id)
        {
            con.ConnectionString = strConnectionString;
            cmd.CommandText = "delete from PermissionTypes where ID = " + id + ")";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            if (con.State != ConnectionState.Open)
                con.Open();

            int reg = cmd.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

            if (reg != 0)
                return true;
            else
                return false;
        }

        public PermissionTypes Select(int id)
        {
            PermissionTypes tipo = new PermissionTypes();
            SqlDataReader rd;

            con.ConnectionString = strConnectionString;
            cmd.CommandText = "select ID, Description from PermissionTypes where ID = " + id + ")";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            if (con.State != ConnectionState.Open)
                con.Open();

            rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                tipo = new PermissionTypes();

                tipo.ID = Convert.ToInt32(rd[0]);
                tipo.Description = rd[1].ToString();
            }

            if (con.State != ConnectionState.Closed)
                con.Close();

            return tipo;
        }

        public List<PermissionTypes> Select()
        {
            List<PermissionTypes> tipos = new List<PermissionTypes>();
            PermissionTypes tipo;
            SqlDataReader rd;

            con.ConnectionString = strConnectionString;
            cmd.CommandText = "select ID, Description from PermissionTypes";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();

            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                tipo = new PermissionTypes();

                tipo.ID = Convert.ToInt32(rd[0]);
                tipo.Description = rd[1].ToString();
                
                tipos.Add(tipo);
            }

            if (con.State != ConnectionState.Closed)
                con.Close();

            return tipos;
        }
    }
}
