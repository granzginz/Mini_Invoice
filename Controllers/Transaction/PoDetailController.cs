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
    public class PoDetailController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PoDetailController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [Authorize]
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select PO_H_ID,PO_D_ID,PO_D_Grid_ID,SubTotal,Discount_Name,Discount,Total from dbo.Tbl_T_PO_Detail";

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
        public JsonResult Post(ModelPoDetail body)
        {
            var outGUID_D = System.Guid.NewGuid();
            var outGUID_Inner_D = System.Guid.NewGuid();

            string query = @"insert into dbo.Tbl_T_PO_Detail values 
                           ( '" + body.PO_H_ID + @"'
                             ,'" + outGUID_D + @"'
                             ,'" + outGUID_Inner_D + @"'
                             ,'" + body.SubTotal + @"'
                             ,'" + body.Discount_Name + @"'
                             ,'" + body.Discount + @"'
                             ,'" + body.Total + @"'
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

            return new JsonResult(new
            {
                message = "Add Succesfully",
                respoutGUID_D = outGUID_D,
                respoutGUID_Inner_D = outGUID_Inner_D
            });
        }

        [Authorize]
        [HttpPut]
        public JsonResult Put(ModelPoDetail body)
        {
            string query = @"
                             Update dbo.Tbl_T_PO_Detail
                                set SubTotal = '" + body.SubTotal + @"'
                                ,Discount_Name = '" + body.Discount_Name + @"'
                                ,Discount = '" + body.Discount + @"'
                                ,Total = '" + body.Total + @"'
                                   where PO_D_ID = '" + body.PO_D_ID + @"'
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
        public JsonResult Delete(ModelPoDetail body)
        {
            string query = @"
                             delete from dbo.Tbl_T_PO_Detail
                                   where PO_D_ID = '" + body.PO_D_ID + @"'
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
