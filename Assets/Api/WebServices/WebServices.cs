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
}
