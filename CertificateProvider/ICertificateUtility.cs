using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CertificateProvider
{
    public interface ICertificateUtility
    {
        public X509Certificate2 CreateSelfSignedCertificate(string name);
    }
}
