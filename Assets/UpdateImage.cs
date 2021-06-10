﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateImage : MonoBehaviour
{
    public Image[] sprites;
    private int num;


    void Awake()
    {
        num = 0;
    }


    public void addSprite(Sprite sprite)
    {
        if (num == 4)
        {
            num = 0;
        }
        sprites[num].sprite = sprite;
        num++;


    }


    public void cleanImages()
    {
        this.num = 0;
        for (int i = 0; i < this.sprites.Length; i++) {
            if (this.sprites[i].sprite != null) {
                this.sprites[i].sprite = null; 
            }
        }

    }


}
