namespace aspnetcoremvcapp.Patterns
{
    public interface IUserSubscriber
    {
    }

    public class BaseSubscriber : IUserSubscriber
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }

    public interface IStandardSubscriber
    {
        void AccessToLimitedTitles();
    }

    public interface IPremiumSubscriber
    {
        void AccessToUnlimitedLimitedTitles();

        void GiveAccessToFamilyMembers();
    }

    public class StandardSubscriber : IUserSubscriber, IStandardSubscriber
    {
        public void AccessToLimitedTitles()
        {
            
        }
    }

    public class PremiumSubscriber : IUserSubscriber, IPremiumSubscriber
    {
        public void AccessToUnlimitedLimitedTitles()
        {

        }

        public void GiveAccessToFamilyMembers()
        {

        }
    }
}
