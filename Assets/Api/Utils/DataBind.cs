using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class VoBind
{
    public string Key;
    public GameObject Target;
}

public class DataBind : MonoBehaviour {

    public List<VoBind> ListToBind = new List<VoBind>();
   

    public void SetData(VoItem list)
    {

        foreach (VoBind voBind in ListToBind)
        {
            //voBind.Target.GetComponent<Text>().text = list."label");


        }
        
    }

}
