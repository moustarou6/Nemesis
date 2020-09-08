using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VoSpaceship : MonoBehaviour {

	public int 			id;   
    public int          user_has_invTypesID;
    public string       url;
    public string       label;


    public VoItem VoItem;


    /* public Vector3 		position;
     public float user_deuterium_stock;
     public float user_iridium_stock;
     public float user_belium_stock;
     public float shield;
     public int life;
     */

    public List<VoSlot> equipment_slot = new List<VoSlot>();
    //public List<> equipment_slot = new List();
}




