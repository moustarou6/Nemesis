using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class PlanetsServices  {

    private static string URL_LIST = "Planets/getPlanets.php";
    public static IEnumerator GetList(Action successCallback = null, Action<string> errorCallback = null)
    {
       

        WWW ws = new WWW(Proxy.HOST + URL_LIST);
        yield return ws;

        if (ws.error == null)
        {
            JSONNode json = JSONNode.Parse(ws.text);


            if (json["status"].Value == "ok")
            {
                AManager.Instance.ListPlanet = new List<VoPlanet>();
                foreach (JSONNode Result in json["result"])
                {
                    VoPlanet Planet = new VoPlanet();
                    Planet.id = Result["id"].AsInt;
                    Planet.label = Result["name"].ToString();
                    Planet.pos_X = Result["position"]["x"].AsInt;
                    Planet.pos_Y = Result["position"]["y"].AsInt;
                    Planet.pos_Z = Result["position"]["z"].AsInt;

                    AManager.Instance.ListPlanet.Add(Planet);
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
}
