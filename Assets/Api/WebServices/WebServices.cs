using System;
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
}
