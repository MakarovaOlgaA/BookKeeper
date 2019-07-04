using System;
namespace BookKeeper
{
    using BookKeeper.Models;
    using System.Collections.Generic;
    using UserDataAPI.Models;

    public class BaseUserResultHandler : IUserResultHandler
    {
        protected IUserResultHandler nextHandler;

        public virtual void Handle(UserResult initialUserResult, DateTime startDate, DateTime endDate, ref IEnumerable<UserResultVM> userResults)
        {
        }

        public void SetNext(IUserResultHandler handler)
        {
            nextHandler = handler;
        }
       
        protected void Proceed(UserResult initialUserResult, DateTime startDate, DateTime endDate, ref IEnumerable<UserResultVM> userResults)
        {
            if(this.nextHandler != null)
            {
                this.nextHandler.Handle(initialUserResult, startDate, endDate, ref userResults);
            }
        }
    }
}
