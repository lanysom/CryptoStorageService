using Xunit;
using CertificateProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificateProvider.Tests
{
    public class CertificateUtilityTests
    {
        [Fact]
        public void CreateSelfSignedCertificateTest()
        {
            CertificateUtility util = new();

            var cert = util.CreateSelfSignedCertificate("test");

            Assert.True(false, "This test needs an implementation");
        }
    }
}