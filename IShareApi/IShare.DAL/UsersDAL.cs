using IShare.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace IShare.DAL
{
    public class UsersDAL
    {
        public static string constr = "Data Source=DESKTOP-FG071FQ;Initial Catalog=IShareData;Integrated Security=True";
        SqlHelper sh = new SqlHelper(constr);
        public void InsertRecord(Users md) 
        {
            sh.ExecuteNoneQuery(
                @"INSERT INTO Users
                    (UserNo,UserName,Password) VALUES
                    (@UserNo,@UserName,@Password)",
                new SqlParameter("@UserNo",md.UserNo),
                new SqlParameter("@UserName", md.UserName),
                new SqlParameter("@PassWord", md.PassWord)
                );
        }

        public object InsertBackRecord(Users md)
        {
           return sh.ExecuteNoneQuery(
                @"INSERT INTO Users
                    (UserNo,UserName,Password)
                    OUTPUT inserted.id VALUES
                    (@UserNo,@UserName,@Password)",
                new SqlParameter("@UserNo", md.UserNo),
                new SqlParameter("@UserName", md.UserName),
                new SqlParameter("@PassWord", md.PassWord)
                );
        }

        public void DeletedRecord() 
        {
            sh.ExecuteNoneQuery(@"DELETE FROM Users");
        }

        public void DeletedRecordById(int id)
        {
            sh.ExecuteNoneQuery(@"DELETE FROM Users WHERE Id=@Id",
            new SqlParameter("@Id", id));
        }

        public void UpdateRecord(Users md) 
        {
            sh.ExecuteNoneQuery(
                "UPDATE Users SET " +
                "UserNo=@UnserNo, UserName=@UserName,Password=@Password WHERE Id=@Id",
                new SqlParameter("@Id", md.Id),
                new SqlParameter("@UserNo", md.UserNo),
                new SqlParameter("@UserName", md.UserName),
                new SqlParameter("@PassWord", md.PassWord)
                );
        }

        public IEnumerable<Users> ListAll() 
        {
            List<Users> users = new List<Users>();
            DataTable dt = sh.ExecuteTable(@"SELECT * FROM Users");
            foreach (DataRow dr in dt.Rows) 
            {
                users.Add(ToModel(dr));
            }
            return users;
        }

        public IEnumerable<Users> ListById(int id)
        {
            List<Users> users = new List<Users>();
            DataTable dt = sh.ExecuteTable(@"SELECT * FROM Users WHERE Id = @Id", new SqlParameter("@Id",id));
            foreach (DataRow dr in dt.Rows)
            {
                users.Add(ToModel(dr));
            }
            return users;
        }

        public IEnumerable<Users> ListAllOfPage(int? startPage, int? endPage)
        {
            List<Users> list = new List<Users>();
            DataTable dt = sh.ExecuteTable(@"SELECT * FROM (SELECT *, ROW_NUMBER() OVER(ORDER BY Id) AS num FROM Users) AS PageTable WHERE PageTable.num BETWEEN @startPage AND @endPage",
                new SqlParameter(@"startPage", startPage),
                new SqlParameter(@"endPage", endPage)
                );
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ToModel(dr));
            }
            return list;
        }

        private Users ToModel(DataRow dr) 
        {
            Users md = new Users();
            md.Id = (int)dr["Id"];
            md.UserNo = dr["UserNo"].ToString();
            md.UserName = dr["UserName"].ToString();
            md.PassWord = dr["PassWord"].ToString();

            return md;
        }
    }
}
