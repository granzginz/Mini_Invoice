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
    public class PoHeaderController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PoHeaderController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        // [Authorize]
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select PO_H_ID, Currency_ID, Addr_From, Addr_To, Date, InvoiceDue, PO_Number, Inv_Number, Logo from dbo.Tbl_T_PO_Header";

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
        public JsonResult Post(ModelPoHeader body)
        {
            string query = @"insert into dbo.Tbl_T_PO_Header values 
                           ( '" + body.PO_H_ID + @"'
                             , '" + body.Currency_id + @"'
                             ,'" + body.Addr_From + @"'
                             ,'" + body.Addr_To + @"'
                             ,'" + body.Date + @"'
                             ,'" + body.InvoiceDue + @"'
                             ,'" + body.PO_Number + @"'
                             ,'" + body.Inv_Number + @"'
                             ,'" + body.Logo + @"'
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
        public JsonResult Put(ModelPoHeader body)
        {
            string query = @"
                             Update dbo.Tbl_T_PO_Header
                                set Currency_ID = '" + body.Currency_id + @"'
                                ,Addr_From = '" + body.Addr_From + @"'
                                ,Addr_To = '" + body.Addr_To + @"'
                                ,Date = '" + body.Date + @"'
                                ,InvoiceDue = '" + body.InvoiceDue + @"'
                                ,PO_Number = '" + body.PO_Number + @"'
                                ,Inv_Number = '" + body.Inv_Number + @"'
                                ,Logo = '" + body.Logo + @"'
                                   where PO_H_ID = '" + body.PO_H_ID + @"'
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
                             delete from dbo.Tbl_T_PO_Header
                                   where PO_H_ID = '" + id + @"'
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
