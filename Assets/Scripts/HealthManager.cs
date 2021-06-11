using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Completed;

public class HealthManager : MonoBehaviour
{

    public Image[] hearts;
    private int count = 5;
    public Sprite heartSprite;
    // Start is called before the first frame update


    private void Awake()
    {


    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void decreaseHealth()
    {
        if (this.count != 0)
        {
            this.count--;
            setNull(count); 
        }
        if (this.count == 0)
        {
            Debug.Log("Game over!!");
            this.hearts[0].sprite = null;
            GameManager.instance.boardScript.setValues();
            GameManager.instance.InitGame();
            resetAll();
            setNull(this.count);
        }

    }

    public void setNull(int i)
    {
        for (int j = i; j < this.hearts.Length; j++)
        {
            this.hearts[i].sprite = null;
        }

    }


    public void resetAll()
    {
        this.count = 5;
        foreach (Image img in this.hearts)
        {
            img.sprite = this.heartSprite;
        }
    }


    public void increaseHealth(int i) {
        for (int j = this.count - 1; j < i; j++) {
            this.hearts[j].sprite = this.heartSprite; 
        }
    }


}
