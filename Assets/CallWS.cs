using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallWS : MonoBehaviour {


    public TreeViewControl TreeView;

    // Use this for initialization
    void Start () {

        MenuFlow.Instance.ChangeState(MenuFlow.GameState.STATE_View);



       // WebServices.Login("mika", "mika123");

    }




    
    
     

    

    

   

    // Update is called once per frame
    void Update () {
		
	}
}
