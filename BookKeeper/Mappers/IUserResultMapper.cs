namespace BookKeeper.Mappers
{
    using BookKeeper.Models;
    using UserDataAPI.Models;

    public interface IUserResultMapper
    {
        UserResultVM GetUser(long userId, UserResult userResult);
    }
}
