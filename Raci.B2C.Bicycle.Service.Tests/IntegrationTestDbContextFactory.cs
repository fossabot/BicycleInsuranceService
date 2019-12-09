using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raci.B2C.Bicycle.Service.DataAccess;
using Raci.B2C.Bicycle.Service.Models;

namespace Raci.B2C.Bicycle.Service.Tests
{
    public class IntegrationTestDbContextFactory : IContextFactory
    {
        private readonly string _tempFile;

        public string ConnectionString =>
            $@"Data Source=(localdb)\MSSQLLocalDB; Integrated Security=True; MultipleActiveResultSets=True; AttachDbFilename={
                _tempFile}";

        public IntegrationTestDbContextFactory()
        {
            _tempFile = $"{System.IO.Path.GetTempPath()}{Guid.NewGuid().ToString()}.mdf";
        }

        private bool _initialized = false;

        public InsuranceDbContext CreateContext()
        {
            InsuranceDbContext context = new InsuranceDbContext(ConnectionString);

            if (!_initialized)
            {
                context.Database.CreateIfNotExists();
                _initialized = true;
            }

            return context;
        }


        public void Cleanup()
        {
            InsuranceDbContext context = new InsuranceDbContext(ConnectionString);
            context.Database.Delete();

            File.Delete(_tempFile);
        }
    }
}
