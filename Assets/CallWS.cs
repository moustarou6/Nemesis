using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallWS : MonoBehaviour {


    public GameObject parent;
    public Dropdown Drop;
	// Use this for initialization
	void Start () {

        WebServices.GetItemByCategory(6, OnSucess);


        Drop.onValueChanged.AddListener(delegate {
            DropdownValueChanged(Drop);
        });


    }


    public ScrollManager ScrollManager;

    void DropdownValueChanged(Dropdown change)
    {

        /* foreach (VoItem item in Group.ListItem)
         {
             StartCoroutine(setImage(item));
         }*/

        Debug.Log("New Value : " + AManager.instance.ListItem[change.value].label);
        Debug.Log("New Value : " + AManager.instance.ListItem[change.value].ListItem.Count);


        ScrollManager.GenerateScroll(AManager.instance.ListItem[change.value].ListItem);
        Debug.Log("New Value : " + AManager.instance.ListItem[change.value].label) ;
    }

    void OnSucess(List<VoGroup> ListItem)
    {

        List<string> ListDrop = new List<string>();
        foreach (VoGroup Group in ListItem)
        {
            ListDrop.Add(Group.label);

         /*   Debug.Log("OnSucess" + ListItem.Count + "---" + AManager.instance.ListVoItem.Count);
            foreach (VoItem item in Group.ListItem)
            {
                StartCoroutine(setImage(item));
            }*/


        }

        Drop.AddOptions(ListDrop);

        
    }

   

    // Update is called once per frame
    void Update () {
		
	}
}
