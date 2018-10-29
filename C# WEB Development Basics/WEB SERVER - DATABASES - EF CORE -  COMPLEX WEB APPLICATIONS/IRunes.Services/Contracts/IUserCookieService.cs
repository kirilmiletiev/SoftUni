﻿namespace IRunes.Services.Contracts
{
    public interface IUserCookieService
    {
        string GetUserCookie(string username);

        string GetUserData(string cookieContent);
    }
}