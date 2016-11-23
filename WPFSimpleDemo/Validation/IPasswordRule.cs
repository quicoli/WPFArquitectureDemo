namespace WPFSimpleDemo.Validation
{
    /// <summary>
    /// Check password follows security rules
    /// </summary>
    public interface IPasswordRule
    {
        bool Passed(string password);
        string ErrorMessage { get; set; }
    }
}