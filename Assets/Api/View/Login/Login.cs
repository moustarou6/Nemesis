using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class Login : MonoBehaviour {

    [Header("Formulaire Login")]
    public Text LoginField;
    public Text PasswordField;

	//private string login;
	//private string pass;
	
	//private string password 	 	="mika123";
	//private string loginField     	="mika";
	//private bool loginMod	 		= true;
	//private string email			= "email";
	//private bool loginIsFailed		= false;
	//public string serveur 			= "http://localhost/backoffice/ws/index.php/";

	//public Camera cameLoading;
    //public Animator loadingAnimator;
	//private string jsonResult;

   // Use this for initialization

	void Awake()
	{
		//AManager.instance.host = serveur;     
	}

    public void Start()
    {
       
    }

	

	public void Valid()
	{
        Debug.Log("Valid");
        WebServices.Login(LoginField.text, PasswordField.text, OnSuccess);
	}

    private void OnSuccess(VoUser voUser)
    {
        Debug.Log("send vo : " + voUser.id);
        Debug.Log("intance : " + AManager.instance.user.id);
    }


	private void LoadNewScene() {  Application.LoadLevel("Menu"); }

	/*private SimpleJSON.JSONNode parseJson(string str)
	{
		Debug.Log("Response : " + str);
		SimpleJSON.JSONNode N = SimpleJSON.JSON.Parse(str);
		return N;
	}*/
	
	/*private IEnumerator addUser(string __login,string __pass,string __email)
	{
		Debug.Log("Web Service Call : " + serveur + "user/add");
		
		var form = new WWWForm();	
		form.AddField("login", __login);
		form.AddField("password", __pass);
		form.AddField("email", __email);
		
		WWW jsonWww = new WWW(serveur + "user/add",form);
		yield return jsonWww;
		parseJson(jsonWww.text);
	}*/
	
	void Update () {
		
	}
	
	/*private IEnumerator loadListSpaceShip(){
		
		Debug.Log("Web Service Call : " + serveur+"spaceship/list");

		WWW www = new WWW(serveur+"spaceship/list");	
		yield return www;
		//StartCoroutine(WaitForRequest(www));

		SimpleJSON.JSONNode wwwString = SimpleJSON.JSON.Parse(www.text);
		Debug.Log("Web Service Response spaceship/list : " + www.text);
		if(wwwString["status"].Value == "ok")
		{
			foreach(SimpleJSON.JSONNode space  in wwwString["result"].AsArray)
			{
				VoSpaceship voSpaceShip = new VoSpaceship();
				voSpaceShip.id				=		space["id"].AsInt;
				voSpaceShip.path 			= 		space["path"].Value;
                voSpaceShip.spaceShip_name  =       space["name"].Value;
				voSpaceShip.price 			= 		space["price"].AsInt;
				voSpaceShip.module_limit	=		space["module_limit"].AsInt;
				voSpaceShip.power			=		space["power"].AsInt;
				voSpaceShip.shield			=		space["shield"].AsInt;
				AManager.instance.listSpaceShip.Add(voSpaceShip);
			}	

		}
		else
		{
			Debug.Log("Erreur loding SpaceShopList");

		}
	}*/
}
