using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class InventorySystem : MonoBehaviour
{


    private Canvas canvas;
    private Inventory inventory;
    // Start is called before the first frame update


    public Canvas getCanvas() {
        return this.canvas; 
    }

    private void Awake()
    {
        
        
    }
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>(); 
        this.inventory = new Inventory(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void addElement(GameObject gameObject) {
        
        inventory.addInventory(gameObject);
        UpdateImage updater = canvas.GetComponent<UpdateImage>();
        SpriteRenderer sprirenderer = gameObject.GetComponent<SpriteRenderer>();
        updater.addSprite(sprirenderer.sprite);
    }
}
