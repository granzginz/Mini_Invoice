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

        // [Authorize]
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select PO_H_ID,PO_D_ID,Name,Quantity, Rate, Amount,SubTotal,Discount,Total,UOM_ID,PO_Number from dbo.Tbl_T_PO_Detail";

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
        public JsonResult Post(ModelPoDetail body)
        {
            string query = @"insert into dbo.Tbl_T_PO_Detail values 
                           ( '" + body.PO_H_ID + @"'
                             , '" + body.PO_D_ID + @"'
                             ,'" + body.Name + @"'
                             ,'" + body.Quantity + @"'
                             ,'" + body.Rate + @"'
                             ,'" + body.Amount + @"'
                             ,'" + body.SubTotal + @"'
                             ,'" + body.Discount + @"'
                             ,'" + body.Total + @"'
                             ,'" + body.UOM_ID + @"'
                             ,'" + body.PO_Number + @"'
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
        public JsonResult Put(ModelPoDetail body)
        {
            string query = @"
                             Update dbo.Tbl_T_PO_Detail
                                set Name = '" + body.Name + @"'
                                ,Quantity = '" + body.Quantity + @"'
                                ,Rate = '" + body.Rate + @"'
                                ,Amount = '" + body.Amount + @"'
                                ,SubTotal = '" + body.SubTotal + @"'
                                ,Discount = '" + body.Discount + @"'
                                ,Total = '" + body.Total + @"'
                                ,UOM_ID = '" + body.UOM_ID + @"'
                                ,PO_Number = '" + body.PO_Number + @"'
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

        // [Authorize]
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                             delete from dbo.Tbl_T_PO_Detail
                                   where PO_D_ID = '" + id + @"'
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
