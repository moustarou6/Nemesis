using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallWS : MonoBehaviour {


    public GameObject parent;
	// Use this for initialization
	void Start () {

        WebServices.GetItemByCategory(6, OnSucess);
		
	}

    void OnSucess(List<VoGroup> ListItem)
    {
        foreach (VoGroup Group in ListItem)
        {

       
            Debug.Log("OnSucess" + ListItem.Count + "---" + AManager.instance.ListVoItem.Count);
            foreach (VoItem item in Group.ListItem)
            {
                StartCoroutine(setImage(item));
            }
        }
    }

    IEnumerator setImage(VoItem item)
    {
        Debug.Log("setImage" + item.url);
        WWW www = new WWW(item.url);
        yield return www;

        // calling this function with StartCoroutine solves the problem
        Debug.Log("Why on earh is this never called?");
        item.thumb = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));

        GameObject image = new GameObject();
        image.AddComponent<Image>().sprite = item.thumb;
        image.transform.parent = parent.transform;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
