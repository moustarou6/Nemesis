using System;
using System.Collections.Generic;
using UnityEngine;

/**
* Class Webservice
*
* @class WebServices
* @constructor
*/
public static class WebServices {
	

    public static void GetListCategories(Action successCallback = null, Action<string> errorCallback = null)
    {
        StaticCoroutine.DoCoroutine(CategoriesServices.GetList(successCallback, errorCallback));
    }
    public static void GetItemByCategory(int categoryID, Action<List<VoGroup>> successCallback = null, Action<string> errorCallback = null)
    {
        StaticCoroutine.DoCoroutine(CategoriesServices.GetItemByCategory(categoryID, successCallback, errorCallback));
    }

    public static void Login(string login, string password, Action<VoUser> successCallback = null, Action<string> errorCallback = null)
    {
        StaticCoroutine.DoCoroutine(UsersServices.LoginWS(login, password, successCallback, errorCallback));
    }

   /* public static void InfoUserShip(int user_id, Action<string> successCallback = null, Action<string> errorCallback = null)
    {
        StaticCoroutine.DoCoroutine(UsersServices.InfoUserShipWS(user_id, successCallback, errorCallback));
    }*/
}
