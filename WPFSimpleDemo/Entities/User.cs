namespace WPFSimpleDemo.Entities
{
    public class User: BaseEntity<User>
    {
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
    }
}