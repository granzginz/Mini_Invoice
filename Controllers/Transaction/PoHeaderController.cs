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

        [HttpGet("GetSelected")]
        public JsonResult GetSelected(ModelPoHeader body)
        {
            string query = @"select poh.PO_H_ID, poh.Currency_ID, poh.Addr_From, poh.Addr_To, poh.Date, poh.InvoiceDue, poh.PO_Number, poh.Inv_Number, poh.Logo, poh.Language_ID,Name_Customer, ml.Initial LangInitial_ID, mc.Initial CurrInitial_ID from dbo.Tbl_T_PO_Header poh
inner join Tbl_M_Language ml on ml.Language_ID = poh.Language_ID
inner join Tbl_M_Currency mc on mc.Currency_ID = poh.Currency_ID
where poh.PO_H_ID = '" + body.PO_H_ID + "'";

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
        [HttpGet("GetPaging")]
        public JsonResult Get()
        {
            string query = @"select poh.PO_H_ID, poh.Currency_ID, poh.Addr_From, poh.Addr_To, poh.Date, poh.InvoiceDue, poh.PO_Number, poh.Inv_Number, poh.Logo, poh.Language_ID,Name_Customer, ml.Initial LangInitial_ID, mc.Initial CurrInitial_ID from dbo.Tbl_T_PO_Header poh
inner join Tbl_M_Language ml on ml.Language_ID = poh.Language_ID
inner join Tbl_M_Currency mc on mc.Currency_ID = poh.Currency_ID";

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
                data = table
            });
        }

        [Authorize]
        [HttpPost]
        public JsonResult Post(ModelPoHeader body)
        {
            var outGUID = System.Guid.NewGuid();
            string query = @"insert into dbo.Tbl_T_PO_Header values 
                           ( '" + outGUID + @"'
                             , '" + body.Currency_id + @"'
                             ,'" + body.Addr_From + @"'
                             ,'" + body.Addr_To + @"'
                             ,'" + body.Date.ToString("yyyy-mm-dd") + @"'
                             ,'" + body.InvoiceDue.ToString("yyyy-mm-dd") + @"'
                             ,'" + body.PO_Number + @"'
                             ,'" + body.Inv_Number + @"'
                             ,'" + body.Logo + @"'
                             ,'" + body.Language_id + @"'
                            ,'" + body.Name_Customer + @"'
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
                respoutGUID = outGUID
            });
        }

        [Authorize]
        [HttpPut]
        public JsonResult Put(ModelPoHeader body)
        {
            string query = @"
                             Update dbo.Tbl_T_PO_Header
                                set Currency_ID = '" + body.Currency_id + @"'
                                ,Addr_From = '" + body.Addr_From + @"'
                                ,Addr_To = '" + body.Addr_To + @"'
                                ,Date = '" + body.Date.ToString("yyyy-mm-dd") + @"'
                                ,InvoiceDue = '" + body.InvoiceDue.ToString("yyyy-mm-dd") + @"'
                                ,PO_Number = '" + body.PO_Number + @"'
                                ,Inv_Number = '" + body.Inv_Number + @"'
                                ,Logo = '" + body.Logo + @"'
                                ,Language_ID = '" + body.Language_id + @"'
                                ,Name_Customer = '" + body.Name_Customer + @"'
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

        [Authorize]
        [HttpDelete]
        public JsonResult Delete(ModelPoHeader body)
        {
            string query = @"
                             delete from dbo.Tbl_T_PO_Header
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

            return new JsonResult("Delete Succesfully");
        }

    }
}
