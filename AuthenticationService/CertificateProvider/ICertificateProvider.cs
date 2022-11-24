using System.Security.Cryptography.X509Certificates;

namespace AuthenticationService.CertificateProvider
{
    public interface ICertificateProvider
    {
        X509Certificate2 CreateCertificate();
    }
}
