using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using N5Company.Models;

namespace N5Company
{
    public class PermissionsDTO
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        string strConnectionString = "";

        public bool Insert(Permissions permisos)
        {
            con.ConnectionString = strConnectionString;
            cmd.CommandText = "insert into Permissions (EmployeeForename, EmployeeSurname, PermissionType, PermissionDate) values ('" + permisos.EmployeeForename + "','" + permisos.EmployeeSurname + "'," + permisos.PermissionType + "," + permisos.PermissionDate + ")";
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

        public bool Update(Permissions permisos)
        {
            con.ConnectionString = strConnectionString;
            cmd.CommandText = "update Permissions set EmployeeForename = '" + permisos.EmployeeForename + "', EmployeeSurname = '" + permisos.EmployeeSurname + "', PermissionType = " + permisos.PermissionType + ", PermissionDate = " + permisos.PermissionDate + " where ID = " + permisos.ID + ")";
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
            cmd.CommandText = "delete from Permissions where ID = " + id + ")";
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

        public Permissions Select(int id)
        {
            Permissions permiso = new Permissions();
            SqlDataReader rd;

            con.ConnectionString = strConnectionString;
            cmd.CommandText = "select ID, EmployeeForename, EmployeSurename, PermissionType, PermissionDate from Permissions where ID = " + id + ")";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            if (con.State != ConnectionState.Open)
                con.Open();

            rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                permiso = new Permissions();

                permiso.ID = Convert.ToInt32(rd[0]);
                permiso.EmployeeForename = rd[1].ToString();
                permiso.EmployeeSurname = rd[2].ToString();
                permiso.PermissionType = Convert.ToInt32(rd[3]);
                permiso.PermissionDate = Convert.ToDateTime(rd[4]);
            }

            if (con.State != ConnectionState.Closed)
                con.Close();

            return permiso;
        }

        public List<Permissions> Select()
        {
            List<Permissions> permisos = new List<Permissions>();
            Permissions permiso;
            SqlDataReader rd;

            con.ConnectionString = strConnectionString;
            cmd.CommandText = "select ID, EmployeeForename, EmployeSurename, PermissionType, PermissionDate from Permissions";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();

            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                permiso = new Permissions();

                permiso.ID = Convert.ToInt32(rd[0]);
                permiso.EmployeeForename = rd[1].ToString();
                permiso.EmployeeSurname = rd[2].ToString();
                permiso.PermissionType = Convert.ToInt32(rd[3]);
                permiso.PermissionDate = Convert.ToDateTime(rd[4]);

                permisos.Add(permiso);
            }

            if (con.State != ConnectionState.Closed)
                con.Close();

            return permisos;
        }
    }
}