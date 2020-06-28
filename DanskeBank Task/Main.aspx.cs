﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodingTask;

namespace DanskeBank_Task
{
    public partial class Main : System.Web.UI.Page
    {
        private SqlConnection sqlConnection;

        protected void Page_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Server.MapPath("App_Data\\Arrays.mdf")};Integrated Security=True");
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<int> path;
            string[] numbersString = TextBox1.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[numbersString.Length];
            string numArray = "", numPath = "", reachable;
            bool isReachable, valid = true;

            for (int i = 0; i < numbersString.Length; i++)
            {
                try
                {
                    numbers[i] = Convert.ToInt32(numbersString[i]);
                }
                catch (Exception exception)
                {
                    valid = false;
                    errorMessage.Text = "Incorrect input";
                    successMessage.Text = "";
                }
            }

            isReachable = ArraySolver.Solve(numbers, out path);

            foreach (var num in numbersString)
            {
                numArray += $"{num} ";
            }

            foreach (var num in path)
            {
                numPath += $"{num.ToString()} ";
            }

            reachable = isReachable ? "Reachable" : "Not reachable";

            // SQL Command execution
            if (valid)
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("CreateArray", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Array", numArray);
                sqlCommand.Parameters.AddWithValue("@Reachable", reachable);
                sqlCommand.Parameters.AddWithValue("@Path", (isReachable ? numPath : ""));
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                Clear();
                successMessage.Text = "Array added successfully";
                errorMessage.Text = "";
            }

            ShowData();
        }

        private void Clear()
        {
            TextBox1.Text = "";
            successMessage.Text = errorMessage.Text = "";
        }

        private void ShowData()
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ViewAllArrays", sqlConnection);
            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            sqlConnection.Close();
            gvArrays.DataSource = dt;
            gvArrays.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            bool valid = true;
            int id;
            try
            {
                id = Convert.ToInt32(TextBox2.Text);
            }
            catch (Exception exception)
            {
                valid = false;
                id = 0;
                errorMessage.Text = "Incorrect input";
                successMessage.Text = "";
            }

            if (valid)
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("DeleteArrayByID", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@ArrayID", id);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                Clear();
                successMessage.Text = "Array deleted successfully";
                errorMessage.Text = "";
            }

            ShowData();
        }
    }
}