using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetGenerator : MonoBehaviour {

    //public Text TimerText;
     double t;

    public GameObject cube;
    // Use this for initialization

    public void Initialisation()
    {
        t = PhotonNetwork.time;

        cube.GetComponent<OrbitManager>().SetTime(t);
    }



    // Update is called once per frame
    void Update () {

      //  TimerText.text = PhotonNetwork.time.ToString();


    }




}
