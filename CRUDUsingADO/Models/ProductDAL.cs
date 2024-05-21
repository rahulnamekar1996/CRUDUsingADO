using System.Data.SqlClient;

namespace CRUDUsingADO.Models
{
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;

        public ProductDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string connstr = this.configuration.GetConnectionString("DefaultConnection");
            con = new SqlConnection(connstr);
        }

        // list
        public List<Product> GetProduct()
        {
            List<Product> productlist = new List<Product>();
            string qry = "select * from product";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product pro = new Product();
                    pro.Id = Convert.ToInt32(dr["id"]);
                    pro.Name = dr["name"].ToString();
                    pro.Company = dr["company"].ToString();
                    pro .Price = Convert.ToDouble(dr["price"]);
                    productlist.Add(pro);
                }
            }
            con.Close();
            return productlist;
        }
        // add
        public int AddProduct(Product pro)
        {
            int result = 0;
            string qry = "insert into product values(@name,@company,@price)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", pro.Name);
            cmd.Parameters.AddWithValue("@company", pro.Company);
            cmd.Parameters.AddWithValue("@price", pro.Price);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        //edit
        public int EditProduct(Product pro)
        {
            int result = 0;
            string qry = "update product set name=@name,company=@company, price=@price where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", pro.Name);
            cmd.Parameters.AddWithValue("@company", pro.Company);
            cmd.Parameters.AddWithValue("@price", pro.Price);
            cmd.Parameters.AddWithValue("@id", pro.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        //select single emp
        public Product GetProductById(int id)
        {
            Product pro = new Product();
            string qry = "select * from product where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    pro.Id = Convert.ToInt32(dr["id"]);
                    pro.Name = dr["name"].ToString();
                    pro.Company = dr["company"].ToString();
                    pro.Price = Convert.ToDouble(dr["price"]);
                }
            }
            con.Close();
            return pro;
        }
        // delete
        public int DeleteProduct(int id)
        {
            int result = 0;
            string qry = "delete from product where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
