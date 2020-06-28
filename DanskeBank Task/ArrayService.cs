using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using CodingTask;

namespace DanskeBank_Task
{
    public static class ArrayService
    {
        public static List<NumberArray> GetArrays(string conString)
        {
            List<NumberArray> arrays = new List<NumberArray>();
            using (SqlConnection myConnection = new SqlConnection(conString))
            {
                SqlCommand oCmd = new SqlCommand("ViewAllArrays", myConnection);
                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        NumberArray array = new NumberArray(Convert.ToInt32(oReader["Id"]), oReader["Array"].ToString(), oReader["Reachable"].ToString(), oReader["Path"].ToString());

                        arrays.Add(array);
                    }

                    myConnection.Close();
                }
            }

            return arrays;
        }

        public static NumberArray GetArray(int id, string conString)
        {
            bool any = false;
            NumberArray array = new NumberArray();

            using (SqlConnection myConnection = new SqlConnection(conString))
            {
                SqlCommand oCmd = new SqlCommand("ViewArrayByID", myConnection);
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.AddWithValue("@ArrayId", id);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        array = new NumberArray(Convert.ToInt32(oReader["Id"]), oReader["Array"].ToString(), oReader["Reachable"].ToString(), oReader["Path"].ToString());

                        any = true;
                        break;
                    }

                    myConnection.Close();
                }
                if(!any) array = new NumberArray(-1, "There is no record with this ID", "", "");
            }

            return array;
        }

        public static void PostArray(NumberArray array, string conString)
        {
            List<int> path;
            string[] numbersString = array.Array.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
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

            if (valid && !ArrayContains(numArray, conString))
            {
                using (SqlConnection myConnection = new SqlConnection(conString))
                {
                    myConnection.Open();
                    SqlCommand oCmd = new SqlCommand("CreateArray", myConnection);
                    oCmd.CommandType = CommandType.StoredProcedure;
                    oCmd.Parameters.AddWithValue("@Array", numArray);
                    oCmd.Parameters.AddWithValue("@Reachable", reachable);
                    oCmd.Parameters.AddWithValue("@Path", (isReachable ? numPath : ""));
                    oCmd.ExecuteNonQuery();
                    myConnection.Close();
                }
            }
        }

        public static void DeleteArray(int id, string conString)
        {
            using (SqlConnection myConnection = new SqlConnection(conString))
            {
                myConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("DeleteArrayByID", myConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@ArrayID", id);
                sqlCommand.ExecuteNonQuery();
                myConnection.Close();
            }
        }

        public static bool ArrayContains(string array, string conString)
        {
            bool any = false;

            using (SqlConnection myConnection = new SqlConnection(conString))
            {
                SqlCommand oCmd = new SqlCommand("ViewArrayByArray", myConnection);
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.AddWithValue("@Array", array);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        any = true;
                        break;
                    }

                    myConnection.Close();
                }

                return any;
            }
        }
    }
}