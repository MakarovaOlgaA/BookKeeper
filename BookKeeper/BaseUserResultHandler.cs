using System;
namespace BookKeeper
{
    using BookKeeper.Models;
    using System.Collections.Generic;
    using UserDataAPI.Models;

    public class BaseUserResultHandler : IUserResultHandler
    {
        protected IUserResultHandler nextHandler;

        public virtual void Handle(UserResult initialUserResult, ref IList<UserResultVM> userResults)
        {
        }

        public void SetNext(IUserResultHandler handler)
        {
            nextHandler = handler;
        }
       
    }
}
