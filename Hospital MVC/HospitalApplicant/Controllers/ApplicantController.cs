using HospitalApplicant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApplicant.Controllers
{
    [ApiController]
    public class ApplicantController : Controller
    {
        private IConfiguration configuration;
        public ApplicantController(IConfiguration config)
        {
            configuration = config;
        }

        [HttpGet]
        [Route("Get_Applicants")]
        public IEnumerable<ApplicantsModel> Get_Applicants()
        {
            List<ApplicantsModel> Applicant = new();
            string ConnectionString = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Get_Applicants",
                    Connection = sqlConnection,
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantsModel Doctor = new ApplicantsModel();
                    Doctor.ID = Convert.ToInt32(reader["ID"]);
                    Doctor.Applicant_Name = Convert.ToString(reader["Applicant_Name"]);
                    Doctor.Department = Convert.ToString(reader["Department"]);
                    Doctor.Floor = Convert.ToInt32(reader["Floor"]);
                    Applicant.Add(Doctor);
                }
                return Applicant.ToArray();
            }
        }

        [HttpPost]
        [Route("Add_Applicant")]
        public void Add_Applicant(string AN, string DEP, int FLOOR, int SSN)
        {
            string ConnectionString = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            List<ApplicantsModel> Doctors = new();
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Add_Applicant",
                    Connection = sqlConnection,
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlConnection.Open();
                cmd.Parameters.Add("@AN", SqlDbType.VarChar).Value = AN;
                cmd.Parameters.Add("@DEP", SqlDbType.VarChar).Value = DEP;
                cmd.Parameters.Add("@Floor", SqlDbType.Int).Value = FLOOR;
                cmd.Parameters.Add("@SSN", SqlDbType.Int).Value = SSN;
                cmd.ExecuteNonQuery();
            }
        }

        [HttpDelete]
        [Route("Delete_Applicant")]
        public void Fire_Doctor(int ID)
        {
            List<ApplicantsModel> Doctors = new();
            string ConnectionString = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Delete_Applicant",
                    Connection = sqlConnection,
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlConnection.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
