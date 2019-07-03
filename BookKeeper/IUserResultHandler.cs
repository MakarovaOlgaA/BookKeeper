namespace BookKeeper
{
    using System.Collections.Generic;
    using UserDataAPI.Models;
    using BookKeeper.Models;

    public interface IUserResultHandler
    {
        void SetNext(IUserResultHandler handler);

        void Handle(UserResult initialUserResult, ref IList<UserResultVM> userResults);
    }
}
