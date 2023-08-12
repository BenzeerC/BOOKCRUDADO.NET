using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOOKCRUDADO.NET.Models;

namespace BOOKCRUDADO.NET
{
    public partial class Form1 : Form
    {
        BookCrud crud= new BookCrud();
        DataTable table= new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = new Book();
                book.Book_Name = txtName.Text;
                book.Author = txtAuthor.Text;
                book.Price = Convert.ToInt32(txtPrice.Text);

                int res = crud.AddBook(book);

                if(res > 0)
                {
                    MessageBox.Show("Record Inserted....");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = new Book();
                book.Id=Convert.ToInt32(txtId.Text);
                book.Book_Name = txtName.Text;
                book.Author = txtAuthor.Text;
                book.Price = Convert.ToInt32(txtPrice.Text);

                int res = crud.UpdateBook(book);

                if (res > 0)
                {
                    MessageBox.Show("Updated..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                int res = crud.DeleteBook(Convert.ToInt32(txtId.Text));

                if(res > 0)
                {
                    MessageBox.Show("Record Deleted..");
                }
            }
            catch( Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = crud.GetBookById(Convert.ToInt32(txtId.Text));
                if(book.Id>0)
                {
                    txtName.Text = book.Book_Name;
                    txtAuthor.Text = book.Author;
                    txtPrice.Text = book.Price.ToString();
                }
                else
                {
                    MessageBox.Show("Record Not Found");
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message );
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            DataTable dt = crud.GetBookList();
            dataGridView1.DataSource = dt;
        }
    }
}
