using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MiniInvoiceAPI.Helper;
using System.Data;
using System.Data.SqlClient;
using MiniInvoiceAPI.Model.Transaction;

namespace MiniInvoiceAPI.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoInnerDetailController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PoInnerDetailController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [Authorize]
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select PO_D_Grid_ID,Sequence,Quantity,Rate,Amount,Unit_Name from tbl_T_PO_Inner_Detail";

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

        [Authorize]
        [HttpPost]
        public JsonResult Post(ModelPoInnerDetail body)
        {
            string query = @"insert into dbo.tbl_T_PO_Inner_Detail values 
                           ( '" + body.PO_D_Grid_ID + @"'
                             , '" + body.Sequence + @"'
                             ,'" + body.Quantity + @"'
                             ,'" + body.Rate + @"'
                             ,'" + body.Amount + @"'
                             ,'" + body.Unit_Name + @"'
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

        [Authorize]
        [HttpPut]
        public JsonResult Put(ModelPoInnerDetail body)
        {
            string query = @"
                             Update dbo.tbl_T_PO_Inner_Detail
                                set Quantity = '" + body.Quantity + @"'
                                ,Rate = '" + body.Rate + @"'
                                ,Amount = '" + body.Amount + @"'
                                ,Unit_Name = '" + body.Unit_Name + @"'
                                   where PO_D_ID = '" + body.PO_D_Grid_ID + @"'
                                and Sequence = '" + body.Sequence + @"'
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

        [Authorize]
        [HttpDelete]
        public JsonResult Delete(ModelPoInnerDetail body)
        {
            string query = @"
                             delete from dbo.tbl_T_PO_Inner_Detail
                                   where PO_D_Grid_ID = '" + body.PO_D_Grid_ID + @"'
                                and Sequence = '" + body.Sequence + @"'
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
