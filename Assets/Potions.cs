using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion
{
    public enum potionType { 
        SPEED, 
        HEALTH,
        RESISTANCE 
    }
    private potionType type;
    private int quantity;


    public Potion(potionType type, int quantity) {
        this.type = type;
        this.quantity = quantity; 
    }


    public potionType GetType() {
        return this.type; 
    }

    public int GetQuantity() {
        return this.quantity; 
    }

    public void SetQuantity(int i) {
        this.quantity = i; 
    }



    // Start is called before the first frame update
}
