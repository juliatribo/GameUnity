using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.EventSystems;
using Completed; 

public class Click : MonoBehaviour, IPointerClickHandler
{

    private PlayerScript player;
    private HealthManager healthManager; 
       void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        switch (this.name) {
            case "Speed":
                this.player.increaseSpeed(); 
                
                break;
            case "Health":
                this.player.increaseLife(); 
                break;
            case "Resistance":
                this.player.invincible();
                Invoke("backToNormal", 3f); 
                break; 


        }
        
    }


    public void backToNormal() {
        this.player.setCanTakeDamage(); 
    }

    // Start is called before the first frame update
    void Start() {
        this.player = GameObject.Find("Player(Clone)").GetComponent<PlayerScript>();
                    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
