using Database.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Database.DAL
{
    public class ProductAcessLayer
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLOcalDB;Initial Catalog=Products;Integrated Security=True;";

        public List<ProductModel> GetProductList()
        {
            var productList = new List<ProductModel>();
            string sqlQuery = "SELECT ProductId, ProductName, Price, Count FROM Product";

            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
                SqlDataReader rdr = sqlCmd.ExecuteReader();

                while (rdr.Read())
                {
                    var productModel = new ProductModel();
                    productModel.ProductId = Convert.ToInt32(rdr["ProductId"]);
                    productModel.ProductName = rdr["ProductName"].ToString();
                    productModel.Price = Convert.ToDecimal(rdr["Price"]);
                    productModel.Count = Convert.ToInt32(rdr["Count"]);
                    productList.Add(productModel);
                }

                sqlCon.Close();
            }

            return productList;
        }

        public ProductModel GetProduct(int id)
        {
            var productModel = new ProductModel();

            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                string query = "SELECT ProductId, ProductName, Price, Count FROM Product WHERE ProductId = " + id;
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader rdr = sqlCmd.ExecuteReader();

                while (rdr.Read())
                {
                    productModel.ProductId = Convert.ToInt32(rdr["ProductId"]);
                    productModel.ProductName = rdr["ProductName"].ToString();
                    productModel.Price = Convert.ToDecimal(rdr["Price"]);
                    productModel.Count = Convert.ToInt32(rdr["Count"]);
                }

                sqlCon.Close();
            }

            return productModel;
        }

        public bool AddProduct(ProductModel productModel)
        {
            int result = 0;

            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                string query = "INSERT INTO Product VALUES(@ProductName, @Price, @Count)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ProductName", productModel.ProductName);
                sqlCmd.Parameters.AddWithValue("@Price", productModel.Price);
                sqlCmd.Parameters.AddWithValue("@Count", productModel.Count);

                sqlCon.Open();
                result = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }

            return result == 1;
        }

        public bool UpdateProduct(ProductModel productModel)
        {
            string query = "UPDATE Product SET ProductName = @ProductName, Price = @Price, Count = @Count WHERE ProductId = @ProductId";
            int result = 0;

            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@ProductName", productModel.ProductName);
                sqlCmd.Parameters.AddWithValue("@Price", productModel.Price);
                sqlCmd.Parameters.AddWithValue("@Count", productModel.Count);
                sqlCmd.Parameters.AddWithValue("@ProductId", productModel.ProductId);

                sqlCon.Open();
                result = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }

            return result == 1;
        }

        public bool DeleteProduct(int id)
        {
            string query = "DELETE FROM Product WHERE ProductId = " + id;
            int result = 0;

            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCon.Open();
                result = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }

            return result == 1;
        }
    }
}
