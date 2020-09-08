using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.IO;

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
                AManager.Instance.ListCategories = new List<VoCategories>();
                foreach (JSONNode Result in json["result"])
                {
                    VoCategories VoCategories = new VoCategories();
                    VoCategories.id = Result["categoryID"].AsInt;
                    VoCategories.label = Result["categoryName"].ToString();
                    AManager.Instance.ListCategories.Add(VoCategories);
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

    public static IEnumerator LoadMarketById(int[] categoryArray, Action<float> UpdateCallback = null , Action successCallback = null, Action<string> errorCallback = null)
    {
        //Debug.Log("GetList n=by " + categoryID);
        string jsonInt = "";
        for (int i = 0; i < categoryArray.Length; i++)
        {
            if (i == 0)
            {
                jsonInt += categoryArray[i];
            }
            else
                jsonInt += "," + categoryArray[i];

        }

        Debug.Log(jsonInt);

      
        WWWForm form = new WWWForm();
        form.AddField("categoryID", jsonInt);
      
        WWW ws = new WWW(Proxy.HOST + URL_ITEM_BY_CATEGORY, form);
        yield return ws;
        
        if (ws.error == null)
        {
            JSONNode json = JSONNode.Parse(ws.text);
            Debug.Log("GetList : " + ws.text);
            if (json["status"].Value == "ok")
            {
                
                AManager.Instance.ListItem.Clear();
                float count = json["count"].AsFloat;
                float indexProcessed = 0;

                foreach (JSONNode cat in json["result"])
                {

                    VoCategories Cat = new VoCategories();
                    Cat.label = cat["name"].Value;
                    Cat.id = cat["id"].AsInt;
                    Cat.ListGroup = new List<VoGroup>();

                    foreach (JSONNode group in cat["result"])
                    {
                        VoGroup VoGroup = new VoGroup();
                        VoGroup.ListItem = new List<VoItem>();
                        VoGroup.label = group["groupName"].Value;

                     
                        VoGroup.id = group["groupID"].AsInt;
                        foreach (JSONNode item in group["item"])
                        {

                            VoItem Item = new VoItem();
                            Item.id = item["typeID"].AsInt;
                            Item.label = item["typeName"].ToString();
                            Item.description = item["description"].ToString();
                            Item.url = Proxy.PathThumbItem + item["typeID"].Value + "_64.png";
                            Item.group = VoGroup;
                            Texture2D tex = Resources.Load<Texture2D>("imageEveonline/Type/" + item["typeID"].Value + "_64");
                           
                            Item.thumb = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));

                            if (Item.thumb != null)
                            {
                             
                            }
                            else if (File.Exists(Application.dataPath + "/../image.eveonline.com/Type/" + item["typeID"].Value + "_64.png"))
                            {
                                //Texture2D tex;
                                tex = new Texture2D(4, 4, TextureFormat.DXT1, false);

                                WWW www = new WWW("file://" + Application.dataPath + "/../image.eveonline.com/Type/" + item["typeID"].Value + "_64.png");
                                yield return www;

                                Debug.Log(Application.dataPath + "/../image.eveonline.com/Type/" + item["typeID"].Value + "_64.png");

                                www.LoadImageIntoTexture(tex);
                                Item.thumb = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
                            }
                            else
                            {

                            
                               WWWForm formdl = new WWWForm();
                                formdl.AddField("url", Item.url);

                                WWW wsdl = new WWW("http://54.38.186.186/save.php", formdl);
                                yield return wsdl;
                            }

                            
                            indexProcessed++;

                            if(UpdateCallback != null)
                                UpdateCallback(indexProcessed / count );

                            VoGroup.ListItem.Add(Item);
                        }

                        Cat.ListGroup.Add(VoGroup);

                      //  Cat.group = VoGroup;

                    }

                    AManager.Instance.ListCategories.Add(Cat);

                }
                
                
                successCallback();
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
