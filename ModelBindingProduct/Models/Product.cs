using Microsoft.Data.SqlClient;
using System.Data;
namespace ModelBindingProduct.Models
{
    public class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public int price { get; set; }

        public static List<Product> GetAllProduct()
        {
            List<Product> lstStd = new List<Product>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=KTjune23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Product";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    lstStd.Add(new Product
                    {
                        productId = dr.GetInt32(0),
                        productName = dr.GetString(1),
                        price = dr.GetInt32(2)
                    });
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return lstStd;
        }
        public static void InsertProduct(Product obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=KTjune23;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Product values(@productId,@productName,@price)";

                cmd.Parameters.AddWithValue("@productId", obj.productId);
                cmd.Parameters.AddWithValue("@productName", obj.productName);
                cmd.Parameters.AddWithValue("price", obj.price);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        public static void UpdateProduct(Product obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=KTjune23;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Product set productName=@productName, price=@price where productId=@productId";

                cmd.Parameters.AddWithValue("@productId", obj.productId);
                cmd.Parameters.AddWithValue("@productName", obj.productName);
                cmd.Parameters.AddWithValue("@price", obj.price);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        public static void DeleteProduct(int productId)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=KTjune23;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Product where productId = @productId";

                cmd.Parameters.AddWithValue("@productId", productId);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        public static Product GetSingleProduct(int productId)
        {
            Product obj = new Product();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=KTjune23;Integrated Security=True";

            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Product where productId = @productId";
                cmd.Parameters.AddWithValue("@productId", productId);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    obj.productId = productId;
                    obj.productName = dr.GetString("productName");
                    obj.price = dr.GetInt32("price");

                }
                else
                {
                    //not found
                    obj = null;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return obj;
        }
    }
}
    
