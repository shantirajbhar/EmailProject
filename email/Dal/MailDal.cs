using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using email.Models;
using email.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace email.Dal
{
    public class MailDal
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        public int insertmailService(Mail mail)
        {
            SqlConnection conn = null;
            string sql = "insert into sourcelist(name) values('" + mail.name + "')";
            conn = new SqlConnection(strcon);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int status = cmd.ExecuteNonQuery();
            if (status > 0)
            {
                return status;
            }
            else
            {
                return status;
            }
        }

        public List<Mail> getAllmailtList()
        {
            string sql = "select id,name,status from sourcelist where status='y'";
            List<Mail> groupList = new List<Mail>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                Mail mail = new Mail();
                                mail.id = Convert.ToInt32(dr[0]);
                                mail.name = dr[1].ToString();
                                groupList.Add(mail);
                            }
                        }
                    }

                }
                conn.Close();
            }

                return groupList;
            }
        public List<Mail> getMailbyId(string edit)
        {
            string sql = "select id,name from sourcelist where id ='" + edit + "'";
            List<Mail> editList = new List<Mail>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                Mail mail = new Mail();
                                mail.id = Convert.ToInt32(dr[0]);
                                mail.name = dr[1].ToString();
                                editList.Add(mail);
                            }
                        }
                    }

                }
                conn.Close();
            }
            return editList;
        }


        public int updategroup(Mail mail)
        {
            string sql = "update sourcelist set name='" + mail.name + "' where id='" + mail.id + "'";
            SqlConnection conn = null;
            conn = new SqlConnection(strcon);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int status = cmd.ExecuteNonQuery();
            if (status > 0)
            {
                return status;
            }
            else
            {
                return status;
            }
        }

        public int softDelete(string delete)
        {
            string sql = "update sourcelist set status='N' where id='" + delete + "'";
            SqlConnection conn = null;
            conn = new SqlConnection(strcon);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int status = cmd.ExecuteNonQuery();
            if (status > 0)
            {
                return status;
            }
            else
            {
                return status;
            }
        }

    }

}