using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MiniInvoiceAPI.Helper;
using System.Data;
using System.Data.SqlClient;
using MiniInvoiceAPI.Model.Master;

namespace MiniInvoiceAPI.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PicController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        // [Authorize]
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select PIC_ID,Name from dbo.Tbl_M_PIC";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("LocalCon");

            SqlDataReader myReader;
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                con.Open();
                using SqlCommand mCommand = new SqlCommand(query, con);
                myReader = mCommand.ExecuteReader();
                table.Load(myReader);

                myReader.Close();
                con.Close();
            }

            return new JsonResult(table);
        }

        // [Authorize]
        [HttpPost]
        public JsonResult Post(ModelPic body)
        {
            var PIC_ID = System.Guid.NewGuid();
            string query = @"insert into dbo.Tbl_M_PIC values 
                           ( '" + PIC_ID + @"'
                             , '" + body.Name + @"'
                            )";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("LocalCon");

            SqlDataReader myReader;
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                con.Open();
                using SqlCommand mCommand = new SqlCommand(query, con);
                myReader = mCommand.ExecuteReader();
                table.Load(myReader);

                myReader.Close();
                con.Close();
            }

            return new JsonResult("Add Succesfully");
        }

        // [Authorize]
        [HttpPut]
        public JsonResult Put(ModelPic body)
        {
            string query = @"
                             Update dbo.Tbl_M_PIC
                                set Name = '" + body.Name + @"'
                                   where PIC_ID = '" + body.PIC_ID + @"'
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("LocalCon");

            SqlDataReader myReader;
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                con.Open();
                using SqlCommand mCommand = new SqlCommand(query, con);
                myReader = mCommand.ExecuteReader();
                table.Load(myReader);

                myReader.Close();
                con.Close();
            }

            return new JsonResult("Update Succesfully");
        }

        // [Authorize]
        [HttpDelete]
        public JsonResult Delete(ModelPic body)
        {
            string query = @"
                             delete from dbo.Tbl_M_PIC
                                   where PIC_ID = '" + body.PIC_ID + @"'
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("LocalCon");

            SqlDataReader myReader;
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                con.Open();
                using SqlCommand mCommand = new SqlCommand(query, con);
                myReader = mCommand.ExecuteReader();
                table.Load(myReader);

                myReader.Close();
                con.Close();
            }

            return new JsonResult("Delete Succesfully");
        }

    }
}
