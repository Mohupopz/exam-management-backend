using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Context
{
    public class DataContext : DbContext
    {
        private readonly string _connectionString;

        public DataContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MySqlServerConnection")
                ?? throw new ArgumentNullException("Connection string not found.");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

        public DbSet<StudentMst> Students => Set<StudentMst>();
        public DbSet<SubjectMst> Subjects => Set<SubjectMst>();
        public DbSet<ExamMaster> ExamMasters => Set<ExamMaster>();
        public DbSet<ExamDtls> ExamDetails => Set<ExamDtls>();

    }
}
