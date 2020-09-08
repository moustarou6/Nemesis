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
    public static void LoadMarketById(int[] categoryArray, Action<float> updateCallback = null, Action successCallback = null, Action<string> errorCallback = null)
    {
        StaticCoroutine.DoCoroutine(CategoriesServices.LoadMarketById(categoryArray, updateCallback, successCallback, errorCallback));
    }



    public static void BuyItem(int ItemID,Action successCallback = null, Action<string> errorCallback = null)
    {
        StaticCoroutine.DoCoroutine(UsersServices.BuyItem(ItemID, successCallback, errorCallback));
    }

    public static void Login(string login, string password, Action successCallback = null, Action<string> errorCallback = null)
    {
        StaticCoroutine.DoCoroutine(UsersServices.LoginWS(login, password, successCallback, errorCallback));
    }


    public static void GetListPlanets(Action successCallback = null, Action<string> errorCallback = null)
    {
        StaticCoroutine.DoCoroutine(PlanetsServices.GetList(successCallback, errorCallback));
    }


    /* public static void InfoUserShip(int user_id, Action<string> successCallback = null, Action<string> errorCallback = null)
     {
         StaticCoroutine.DoCoroutine(UsersServices.InfoUserShipWS(user_id, successCallback, errorCallback));
     }*/
}
