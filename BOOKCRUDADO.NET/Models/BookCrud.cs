using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BOOKCRUDADO.NET.Models
{
    public class BookCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public BookCrud()
        {
            string connstr = ConfigurationManager.ConnectionStrings["defaultconnection"].ConnectionString;
            con = new SqlConnection(connstr);
        }

        public Book GetBookById(int id)
        {
            Book book = new Book();
            string qry = "select * from BookADO where Book_Id=@Book_Id ";

            cmd=new SqlCommand(qry,con);

            cmd.Parameters.AddWithValue("@Book_Id", id);

            con.Open();

            dr = cmd.ExecuteReader();

            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    book.Id = Convert.ToInt32(dr["Book_Id"]);
                    book.Book_Name = dr["Book_Name"].ToString();
                    book.Author = dr["Author"].ToString();
                    book.Price = Convert.ToInt32(dr["Price"]);  
                }
            }
            con.Close();
            return book;
        }

        public int AddBook(Book book)
        {
            string qry = "insert into BookADO values(@Book_Name,@Author,@Price)";

            cmd= new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@Book_Name", book.Book_Name);
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@Price", book.Price);

            con.Open();

            int result=cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int UpdateBook(Book book)
        {
            string qry = "update BookADO set Book_Name=@Book_Name,Author=@Author,Price=@Price where Book_Id=@Book_Id";

            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@Book_Name", book.Book_Name);
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@Price", book.Price);
            cmd.Parameters.AddWithValue("@Book_Id", book.Id);

            con.Open();

            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }


        public int DeleteBook(int id)
        {
            string qry = "delete from BookADO where Book_Id=@Book_Id";

            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@Book_Id", id);
            //cmd.Parameters.AddWithValue("@price", prod.Price);
            //cmd.Parameters.AddWithValue("@cid", prod.Cid);

            con.Open();

            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }


        public DataTable GetBookList()
        {
            DataTable dt = new DataTable();
            string qry = "Select * from BookADO";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt.Load(dr);
            }
            con.Close();
            return dt;
        }



    }
}
