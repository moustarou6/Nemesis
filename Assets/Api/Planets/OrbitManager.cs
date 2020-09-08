using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbitManager : MonoBehaviour {

  
    public Vector2 ellipseAxe;
    public float majorAxis;
    public float minorAxis;
    // Use this for initialization

    private double t = 0;
    public Text timer;
    public Text position;
    public void SetTime(double time)
    {
        t = time;
        gameObject.transform.position = new Vector3(
                                                                           ellipseAxe.x + (majorAxis * Mathf.Cos((float)t)),
                                                                           ellipseAxe.y + (minorAxis * Mathf.Sin((float)t)),
                                                                           0.0f
                                                                      );
    }
	
	// Update is called once per frame
	void Update () {

        timer.text = t.ToString();
        if (t != 0)
        {
            t += Time.deltaTime;
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
                                                            new Vector3(
                                                                            ellipseAxe.x + (majorAxis * Mathf.Cos((float)t)),
                                                                            ellipseAxe.y + (minorAxis * Mathf.Sin((float)t)),
                                                                            0.0f
                                                                       ), Time.deltaTime * 0.1f);
            position.text = this.gameObject.transform.position.x + " - " + this.gameObject.transform.position.y;
        }
    }
}
