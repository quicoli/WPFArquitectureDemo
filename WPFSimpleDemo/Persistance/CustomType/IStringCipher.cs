namespace WPFSimpleDemo.Persistance.CustomType
{
    public interface IStringCipher
    {
        string Encrypt(string text);
        string Decrypt(string text);
    }
}