using System.Data.SqlClient;

namespace CRUDUsingADO.Models
{
    public class StudentDAL
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;

        public StudentDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string connstr = this.configuration.GetConnectionString("DefaultConnection");
            con = new SqlConnection(connstr);
        }

        // list
        public List<Student> GetStudent()
        {
            List<Student> studentlist = new List<Student>();
            string qry = "select * from student";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student std = new Student();
                    std.Id = Convert.ToInt32(dr["id"]);
                    std.Name = dr["name"].ToString();
                    std.City = dr["city"].ToString();
                    std.Percentage = Convert.ToDouble(dr["percentage"]);
                    studentlist.Add(std);
                }
            }
            con.Close();
            return studentlist;
        }
        // add
        public int AddStudent(Student std)
        {
            int result = 0;
            string qry = "insert into student values(@name,@city,@percentage)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", std.Name);
            cmd.Parameters.AddWithValue("@city", std.City);
            cmd.Parameters.AddWithValue("@percentage", std.Percentage);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        //edit
        public int EditStudent(Student std)
        {
            int result = 0;
            string qry = "update student set name=@name,city=@city, percentage=@percentage where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", std.Name);
            cmd.Parameters.AddWithValue("@city", std.City);
            cmd.Parameters.AddWithValue("@percentage", std.Percentage);
            cmd.Parameters.AddWithValue("@id", std.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        //select single emp
        public Student GetStudentById(int id)
        {
            Student std = new Student();
            string qry = "select * from student where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    std.Id = Convert.ToInt32(dr["id"]);
                    std.Name = dr["name"].ToString();
                    std.City = dr["city"].ToString();
                    std.Percentage = Convert.ToDouble(dr["percentage"]);
                }
            }
            con.Close();
            return std;
        }
        // delete
        public int DeleteStudent(int id)
        {
            int result = 0;
            string qry = "delete from student where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
