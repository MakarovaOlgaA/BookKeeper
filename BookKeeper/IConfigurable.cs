namespace BookKeeper
{
    using BookKeeper.Models;
    using UserDataAPI.Models;

    public interface IConfigurable
    {
        void Configure(UserResultVM user, UserResult initialUserResult);
    }
}