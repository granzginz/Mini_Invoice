﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MiniInvoiceAPI.Helper;
using System.Data;
using System.Data.SqlClient;
using MiniInvoiceAPI.Model;

namespace MiniInvoiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [Authorize]
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select DepartmentId, DepartmentName from dbo.Department";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("Localcon");

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
        public JsonResult Post(Department department)
        {
            string query = @"insert into dbo.Department values 
                           ( '" + department.DepartmentName + @"')";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("Localcon");

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
        public JsonResult Put(Department department)
        {
            string query = @"
                             Update dbo.Department
                                set DepartmentName = '" + department.DepartmentName + @"'
                                   where DepartmentId = '" + department.DepartmentId + @"'
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");

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
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                             delete from dbo.Department
                                   where DepartmentId = '" + id + @"'
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");

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
