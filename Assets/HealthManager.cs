using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HealthManager : MonoBehaviour
{

    public Image[] hearts;
    private int count = 5; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void decreaseHealth() {
        this.count--;
        if (this.count == 0)
        {
            Debug.Log("Game over!!");
        }
        else {
            setNull(this.count); 
        }

         }

         public void setNull( int i ) { 
            for (int j = i  ; j < this.hearts.Length; j++) {
                    this.hearts[i].sprite = null; 
                }
   
        }

}
