using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class EncryptedUser
    {
        public Guid Id { get; set; }

        public string EncryptedData { get; set; } = string.Empty;

        public string EncryptedKey { get; set; } = string.Empty;
        public string Nonce { get; set; }
        public string Tag { get; set; }
    }
}
