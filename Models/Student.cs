using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace StudentManagementMVC.Models
{
    public class Student
    {
        [Key]
        public int StudentNo { get; set; }

        [Required(ErrorMessage ="student name not enter")]
        [StringLength(50)]
        public string? StudentName { get; set; }

        public int Section { get; set; }

        [Required(ErrorMessage = "student name not enter")]
        [StringLength(10)]
        public string? Branch { get; set; }

        [Required(ErrorMessage = "student name not enter")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string? EmailId { get; set; }

        public static void Insert(Student obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into student values(Name=@name,Section=@section,Branch=@branch,EmailId=@email )";
                /* cmd.Parameters.AddWithValue("@id", obj.StudentNo);*/
                cmd.Parameters.AddWithValue("@id", obj.StudentNo);
                cmd.Parameters.AddWithValue("@name", obj.StudentName);
                cmd.Parameters.AddWithValue("@section", obj.Section);
                cmd.Parameters.AddWithValue("@branch", obj.Branch);
                cmd.Parameters.AddWithValue("@email", obj.EmailId);
                /*cmd.Parameters.AddWithValue("id", obj.StudentNo);*/
                cmd.ExecuteNonQuery();


            }
            catch (Exception) { throw; }
            finally { cn.Close(); }
        }

    

    public static void Update(Student obj) {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update student set Name=@name,Section=@section,Branch=@branch,EmailId=@email where StudentNo=@id";
                cmd.Parameters.AddWithValue("@id", obj.StudentNo);
                cmd.Parameters.AddWithValue("@name", obj.StudentName);
                cmd.Parameters.AddWithValue("@section", obj.Section);
                cmd.Parameters.AddWithValue("@branch", obj.Branch);
                cmd.Parameters.AddWithValue("@email", obj.EmailId);
                /*cmd.Parameters.AddWithValue("id", obj.StudentNo);*/
                cmd.ExecuteNonQuery();
                

            }
            catch (Exception ) { throw; }
            finally { cn.Close(); }
        }

        public static Student GetSingleStudent(int id) {
            Student obj = new Student();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30";

            try { 
            cn.Open();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from student where StudentNo=@studentNo";
            cmdInsert.Parameters.AddWithValue("@studentNo",id);
            SqlDataReader dr = cmdInsert.ExecuteReader();
            if (dr.Read())
            {
                    obj.StudentNo = dr.GetInt32("StudentNo");
                    obj.StudentName = dr.GetString("Name");
                    obj.Section = dr.GetInt32("Section");
                    obj.Branch = dr.GetString("Branch");
                    obj.EmailId = dr.GetString("EmailId");
                }
            else
            {
                obj = null;
                //record not present
            }
            dr.Close();
        }
            catch (Exception )
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
return obj;}
       
        

        public static List<Student> GetAllStudent() { 
            List<Student> list = new List<Student>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "select * from student ";
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                    list.Add(new Student { StudentNo = dr.GetInt32("StudentNo"), StudentName = dr.GetString("Name"), Section = dr.GetInt32("Section"), Branch = dr.GetString("Branch"), EmailId = dr.GetString("EmailId") });
                dr.Close();
            }catch (Exception ) { throw; }    finally { cn.Close(); }
            return list;
        }
    }
}
