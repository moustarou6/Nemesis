﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DataBind : MonoBehaviour {

    private int id = -1;
    public Text PriceText;
    public Text NameText;
    public Image ImageComponent;
    
    public void SetData(VoItem _list)
    {

        if (PriceText != null)
            PriceText.text = _list.price.ToString();

        if (NameText != null)
            NameText.text = _list.label;

        if (ImageComponent != null)
            StartCoroutine(setImage(_list));
            
        
    }


    IEnumerator setImage(VoItem item)
    {

        if (item.thumb == null)
        {
            WWW www = new WWW(item.url);
            yield return www;
            
            item.thumb = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
        }
        ImageComponent.sprite = item.thumb;

    }

}
