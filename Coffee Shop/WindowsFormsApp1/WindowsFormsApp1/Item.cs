using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Item : Form
    {
        public Item()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addvalue1();
         
        }
        private void addvalue1()
        {
            try
            {
                //connection
                string connectionstring = @"Server=LAPTOP-63O1JEB6;Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(connectionstring);
                //command
                string commandstring = @"INSERT INTO Item(Name,Price)VALUES('" + nameTextBox.Text + "'," + priceTextBox.Text + ")";

                SqlCommand sqlcommand = new SqlCommand(commandstring, sqlconnection);

                sqlconnection.Open();
                /*if (Name.Distinct(nameTextBox.Text))
                {
                    MessageBox.Show("Name must be unique!");
                    return;
                }*/
                int isexecute = sqlcommand.ExecuteNonQuery();
                if (isexecute > 0)
                {
                    MessageBox.Show("Value Added.");
                    nameTextBox.Clear();
                    priceTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("No Value Added.");
                }
                sqlconnection.Close();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showvalue1();
        }
        private void showvalue1()
        {
            //connection
            string connectionstring = @"Server=LAPTOP-63O1JEB6;Database=CoffeeShop;Integrated Security=True";
            SqlConnection sqlconnection = new SqlConnection(connectionstring);
            //command
            string commandstring = @"SELECT* FROM Item";
            SqlCommand sqlcommand = new SqlCommand(commandstring, sqlconnection);

            sqlconnection.Open();

            SqlDataAdapter sqldataadapter = new SqlDataAdapter(sqlcommand);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);
            dataGridView.DataSource = datatable;
            sqlcommand.ExecuteNonQuery();

            sqlconnection.Close();


        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            delete1();
        }
        private void delete1()
        {
            
            try
            {
                //connection
                string connectionstring = @"Server=LAPTOP-63O1JEB6;Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(connectionstring);
                //command
                string commandstring = @"DELETE FROM Item WHERE Name='" + nameTextBox.Text + "'";
                SqlCommand sqlcommand = new SqlCommand(commandstring, sqlconnection);

                sqlconnection.Open();
                int isexecution = sqlcommand.ExecuteNonQuery();
                if (isexecution > 0)
                {
                    MessageBox.Show("Data Deleted");
                }
                else
                {
                    MessageBox.Show("Data Not Deleted");

                }
                sqlconnection.Close();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            update1();
        }
        private void update1()
        {
            try
            {
                //connection
                string connectionstring = @"Server=LAPTOP-63O1JEB6;Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(connectionstring);
                //command
                string commandstring = @"UPDATE Item SET Name='" + nameTextBox.Text + "',Price=" + priceTextBox.Text +" WHERE Id="+idTextBox.Text+"";
                SqlCommand sqlcommand = new SqlCommand(commandstring, sqlconnection);

                sqlconnection.Open();
                //int isexecute=
                    sqlcommand.ExecuteNonQuery();
               /* if (isexecute > 0)
                {
                    MessageBox.Show("One value updated");
                }
                else
                {
                    MessageBox.Show("No value updated");

                }*/
                sqlconnection.Close();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            search1();
        }
        private void search1()
        {
            try
            {
                //connection
                string connectionstring = @"Server=LAPTOP-63O1JEB6;Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(connectionstring);
                //command
                string commandstring = @"SELECT* FROM Item WHERE Name='"+nameTextBox.Text+"'";
                SqlCommand sqlcommand = new SqlCommand(commandstring, sqlconnection);

                sqlconnection.Open();

                SqlDataAdapter sqldataadapter = new SqlDataAdapter(sqlcommand);
                DataTable datatable = new DataTable();
                sqldataadapter.Fill(datatable);
                dataGridView.DataSource = datatable;
                sqlcommand.ExecuteNonQuery();
                

                sqlconnection.Close();
            }catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

       
    }
}
