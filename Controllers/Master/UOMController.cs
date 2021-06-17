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
    public class UOMController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UOMController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        // [Authorize]
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select UOM_ID,Unit_Name, Decription from dbo.Tbl_M_UnitOfMeasurement";

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
        public JsonResult Post(ModelUnitOfMeasurement body)
        {
            var UOM_ID = System.Guid.NewGuid();
            string query = @"insert into dbo.Tbl_M_UnitOfMeasurement values 
                           ( '" + UOM_ID + @"'
                             , '" + body.Unit_Name + @"'
                             ,'" + body.Description + @"'
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
        public JsonResult Put(ModelUnitOfMeasurement body)
        {
            string query = @"
                             Update dbo.Tbl_M_UnitOfMeasurement
                                set Unit_Name = '" + body.Unit_Name + @"'
                                ,Decription = '" + body.Description + @"'
                                   where UOM_ID = '" + body.UOM_ID + @"'
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
        public JsonResult Delete(ModelUnitOfMeasurement body)
        {
            string query = @"
                             delete from dbo.Tbl_M_UnitOfMeasurement
                                   where UOM_ID = '" + body.UOM_ID + @"'
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
