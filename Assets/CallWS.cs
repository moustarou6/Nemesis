using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallWS : MonoBehaviour {

	// Use this for initialization
	void Start () {

        WebServices.GetListCategories();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
