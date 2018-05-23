using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class UsersServices
{

    private static string UrlLogin = "User/login.php";
    private static string UrlInfoShip = "User/info";



   /* public static IEnumerator InfoUserShipWS(int user_id, Action<string> successCallback = null, Action<string> errorCallback = null)
    {

        Debug.Log("Web Service Call : " + WebServices.HOST + WebServices.PATH_WS + UrlInfoShip);
        WWWForm form = new WWWForm();
        form.AddField("user_id", user_id);

        WWW jsonWww = new WWW(WebServices.HOST + WebServices.PATH_WS + UrlInfoShip, form);
        yield return jsonWww;
        Debug.Log("Web Service Response user/info : " + jsonWww.text);
        SimpleJSON.JSONNode wwwString = SimpleJSON.JSON.Parse(jsonWww.text);
        if (jsonWww.error == null)
        {
            if (wwwString["status"].Value == "ok")
            {

                VoSpaceship ShipDetails = new VoSpaceship();
                ShipDetails.id = wwwString["result"]["ship_details"]["id"].AsInt;
                ShipDetails.spaceShip_name = wwwString["result"]["ship_details"]["spaceShip_name"].Value;
                ShipDetails.path = wwwString["result"]["ship_details"]["path"].Value;
                ShipDetails.price = wwwString["result"]["ship_details"]["price"].AsInt;
                ShipDetails.power_shield = wwwString["result"]["ship_details"]["power_shield"].AsFloat;
                ShipDetails.power_hull = wwwString["result"]["ship_details"]["power_hull"].AsFloat;
                ShipDetails.power_weapon = wwwString["result"]["ship_details"]["power_weapon"].AsFloat;
                ShipDetails.speed = wwwString["result"]["ship_details"]["speed"].AsFloat;
                ShipDetails.stock = wwwString["result"]["ship_details"]["hold"].AsFloat;


                Debug.Log(ShipDetails.path);

                VoUserSpaceShip UserSpaceShip = new VoUserSpaceShip();
                UserSpaceShip.id = wwwString["result"]["ship_details"]["users_ships_id"].AsInt;
                UserSpaceShip.user_deuterium_stock = wwwString["result"]["ship_details"]["hold_deuterium"].AsFloat;
                UserSpaceShip.user_iridium_stock = wwwString["result"]["ship_details"]["hold_iridium"].AsFloat;
                UserSpaceShip.user_belium_stock = wwwString["result"]["ship_details"]["hold_belium"].AsFloat;
                UserSpaceShip.spaceShip = ShipDetails;
                //UserSpaceShip.position = wwwString["result"]["ship_details"]["position"].Value;
                ///   UserSpaceShip.spaceShip
                //   UserSpaceShip.equipment_slot.

                //       UserSpaceShip.life


                foreach (SimpleJSON.JSONNode slot in wwwString["result"]["slotList"].AsArray)
                {

                    VoEquipmentSlot equipment_slot = new VoEquipmentSlot();
                    equipment_slot.id = slot["id"].AsInt;
                    equipment_slot.number = slot["number"].AsInt;
                    equipment_slot.equipments = new List<VoEquipment>();

                    foreach (SimpleJSON.JSONNode equipments in slot["equipments"].AsArray)
                    {
                        VoEquipment equipment = new VoEquipment();
                        equipment.id = equipments["id"].AsInt;
                        equipment.slot_id = equipments["slot_id"].AsInt;
                        equipment.power = equipments["power"].AsInt;
                        equipment.price = equipments["price"].AsInt;
                        equipment.thumb = WebServices.PathEquipement + equipments["thumb"].Value;
                        equipment.label = equipments["name"].Value;

                        equipment_slot.equipments.Add(equipment);

                    }

                    UserSpaceShip.equipment_slot.Add(equipment_slot);



                    //equipment_slot
                    // voUserSpaceship.equipments.Add(equipment);
                }

                AManager.instance.user.usership = UserSpaceShip;

                if (successCallback != null)
                    successCallback("ok");

           
            }
        }
        else
        {
            Debug.Log("ERROR INFO");
        }
    }*/


    public static IEnumerator LoginWS(string login, string password, Action<VoUser> successCallback = null, Action<string> errorCallback = null)
    {
        Debug.Log("Web Service Call : " + Proxy.HOST + UrlLogin);
        WWWForm form = new WWWForm();

        form.AddField("login", login);
        form.AddField("password", password);

        WWW jsonWww = new WWW(Proxy.HOST + UrlLogin, form);
        yield return jsonWww;
    
        Debug.Log("Web Service Response user/login : " + jsonWww.text);
        SimpleJSON.JSONNode wwwString = SimpleJSON.JSON.Parse(jsonWww.text);
        if (jsonWww.error == null)
        {
            if (wwwString["status"].Value == "ok")
            {
                //StartCoroutine(loadListSpaceShip());
                //StartCoroutine(loadListClassement());

                VoUser voUser       = new VoUser();
                voUser.id           = wwwString["result"]["user"]["id"].AsInt;
                voUser.credit       = wwwString["result"]["user"]["credit"].AsInt;
                voUser.login        = wwwString["result"]["user"]["login"].Value;

                voUser.belium       = wwwString["result"]["user"]["iridium"].AsInt;
                voUser.iridium      = wwwString["result"]["user"]["deuterium"].AsInt;
                voUser.deuterium    = wwwString["result"]["user"]["belium"].AsInt;

                AManager.instance.user = voUser;

             
                 
                if (successCallback != null)
                    successCallback(voUser);
                // Invoke("LoadNewScene", 5);//Application.LoadLevel ("Serveur");
            }
            else
            {
                if (errorCallback != null)
                    errorCallback(wwwString["message"]);
            }
        }
        else
        {
            if (errorCallback != null)
                errorCallback(jsonWww.error);
        }
    }
}
