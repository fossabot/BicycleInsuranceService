using System;
using Raci.B2C.Bicycle.Service.Models;

namespace Raci.B2C.Bicycle.Service.DataAccess
{
    public class DefaultContextFactory : IContextFactory
    {
        private readonly string _connectionString;

        public DefaultContextFactory(string conn)
        {
            if (string.IsNullOrEmpty(conn))
            {
                throw new ArgumentException("", nameof(conn));
            }

            _connectionString = conn;
        }

        public InsuranceDbContext CreateContext()
        {
            return new InsuranceDbContext(_connectionString);
        }
    }
}