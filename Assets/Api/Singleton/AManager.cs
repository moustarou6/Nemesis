using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AManager : MonoBehaviour {
    // s_Instance is used to cache the instance found in the scene so we don't have to look it up every time.
    private static 	AManager s_Instance = null;


    public VoUser user;

    public List<VoCategories> ListCategories = new List<VoCategories>();
    public List<VoGroup> ListItem = new List<VoGroup>();


    // This defines a static instance property that attempts to find the manager object in the scene and
    // returns it to the caller.
    public static AManager instance {
        get {
            if (s_Instance == null) {
                // This is where the magic happens.
                //  FindObjectOfType(...) returns the first AManager object in the scene.
                s_Instance =  FindObjectOfType(typeof (AManager)) as AManager;
            }
 
            // If it is still null, create a new instance
            if (s_Instance == null) {
                GameObject obj = new GameObject("AManager");
                s_Instance = obj.AddComponent(typeof (AManager)) as AManager;
				DontDestroyOnLoad(obj);
                Debug.Log ("Could not locate an AManager object.  AManager was Generated Automaticly.");
            }

		      return s_Instance;
        }
    }
 
    // Ensure that the instance is destroyed when the game is stopped in the editor.
    void OnApplicationQuit() {
       // s_Instance = null;
    }

 }