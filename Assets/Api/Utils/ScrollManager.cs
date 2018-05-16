using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour {

    public GameObject Template;


    public void GenerateScroll(List<VoItem> Objectist)
    {
        Clear();
        foreach (VoItem item in Objectist)
        {
            GameObject Clone = Instantiate(Template,Template.transform.parent);
            Clone.GetComponent<DataBind>().SetData(item);
        }
    }



    public void Clear()
    {
        //List<GameObject> DestoyList = new List<GameObject>();
        foreach (Transform child in Template.transform.parent)
        {
            if (Template != child.gameObject)
            {
                Destroy(child.gameObject);
            }
        }



    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
