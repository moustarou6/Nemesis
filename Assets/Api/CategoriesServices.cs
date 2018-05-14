using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class CategoriesServices {

    private static string URL_LIST = "Market/Category/list.php";


    public static IEnumerator GetList(Action successCallback = null, Action<string> errorCallback = null)
    {
        Debug.Log("GetList");
      /*  WWWForm form = new WWWForm();
        form.AddField("idApplication", ((int)BoxApi.instance.parameters.getParams("ApplicationId")).ToString());
        form.AddField("share_type", "2,3");
        form.AddField("share_data", "1:" + imageName);*/
        
        WWW ws = new WWW( Proxy.HOST + URL_LIST);
        yield return ws;
        
        if (ws.error == null)
        {
            JSONNode json = JSONNode.Parse(ws.text);


            if (json["status"].Value == "ok")
            {
                Debug.Log(json);
            }
            else
            {
                if (errorCallback != null)
                    errorCallback(json["message"]);
            }
        }
        else
        {
            if (errorCallback != null)
                errorCallback(ws.error);
        }

       
    }


}
