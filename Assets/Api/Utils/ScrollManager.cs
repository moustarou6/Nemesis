using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour {

    public GameObject Template;
    public DataBind data;
    private List<VoItem> _currentList;
    public void GenerateScroll(List<VoItem> Objectist)
    {
        _currentList = Objectist;
        Clear();
        for (int i = 0; i< Objectist.Count; i++)
        {
            int j = new int();
            j = i;
            GameObject Clone = Instantiate(Template,Template.transform.parent);
            Clone.SetActive(true);
            Clone.GetComponent<Button>().onClick.AddListener(() => SelectedItem(j));
            Clone.GetComponent<DataBind>().SetData(Objectist[i]);
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

    public void SelectedItem(int i ) // 3
    {     
        data.SetData(_currentList[i]);
    }
}
