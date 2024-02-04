using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EncryptionWithEF
{
    public class EncryptionConverter : ValueConverter<string, string>
    {
        public EncryptionConverter(EncryptionService encryptionService)
            : base(
                v => encryptionService.Encrypt(v),
                v => encryptionService.Decrypt(v))
        {
        }
    }
}
