using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AManager : Singleton<AManager>
{
   

    public VoUser user =  new VoUser();

    public List<VoCategories> ListCategories = new List<VoCategories>();
    public List<VoGroup> ListItem = new List<VoGroup>();
    public List<VoPlanet> ListPlanet = new List<VoPlanet>();


    // This defines a static instance property that attempts to find the manager object in the scene and
    // returns it to the caller.

    // Ensure that the instance is destroyed when the game is stopped in the editor.



    public VoCategories GetShipCategories()
    {

       
        foreach (VoCategories VoCat in ListCategories)
        {            
            if (VoCat.label == "Ship")
                return VoCat;
        }

        return null;
        
    }

    public VoCategories GetModuleCategories()
    {

        foreach (VoCategories VoCat in ListCategories)
        {
            Debug.Log(VoCat.ListGroup.Count);

            if (VoCat.label == "Module")
                return VoCat;
        }

        return null;

    }
}