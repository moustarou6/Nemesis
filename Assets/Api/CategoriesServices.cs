using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class CategoriesServices {

    private static string URL_LIST = "Market/Category/list.php";
    private static string URL_ITEM_BY_CATEGORY = "Market/ItemByCategorylist.php";

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
                AManager.instance.ListCategories = new List<VoCategories>();
                foreach (JSONNode Result in json["result"])
                {
                    VoCategories VoCategories = new VoCategories();
                    VoCategories.id = Result["categoryID"].AsInt;
                    VoCategories.label = Result["categoryName"].ToString();
                    AManager.instance.ListCategories.Add(VoCategories);
                }
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

    public static IEnumerator GetItemByCategory(int categoryID, Action<List<VoGroup>> successCallback = null, Action<string> errorCallback = null)
    {
        Debug.Log("GetList");
        WWWForm form = new WWWForm();
        form.AddField("categoryID",categoryID);
      
        WWW ws = new WWW(Proxy.HOST + URL_ITEM_BY_CATEGORY, form);
        yield return ws;
        
        if (ws.error == null)
        {
            JSONNode json = JSONNode.Parse(ws.text);
            if (json["status"].Value == "ok")
            {

                
                foreach (JSONNode group in json["result"])
                {

                    VoGroup VoGroup = new VoGroup();
                    VoGroup.ListItem = new List<VoItem>();
                    VoGroup.label = group["groupName"].Value;
                    foreach (JSONNode item in group["item"])
                    {
                        VoItem Item = new VoItem();
                        Item.id = item["typeID"].AsInt;
                        Item.label = item["typeName"].ToString();
                        Item.url = Proxy.PathThumbItem + item["typeID"].Value+"_64.png";

                        VoGroup.ListItem.Add(Item);
                      //  AManager.instance.ListVoItem.Add(Item);
                    }

                    AManager.instance.ListItem.Add(VoGroup);

                }
                
                
                successCallback(AManager.instance.ListItem);
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
