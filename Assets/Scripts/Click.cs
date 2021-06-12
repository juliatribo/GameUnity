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
    private Text quantity;
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        int q = int.Parse(this.quantity.text);
        Debug.Log(q);
        if (q != 0)
        {
            switch (this.name)
            {
                case "Speed":
                    this.player.increaseSpeed();
                    this.player.getPotion(Potion.potionType.SPEED).SetQuantity(q - 1); 
                    break;
                case "Health":
                    this.player.increaseLife();
                    this.player.getPotion(Potion.potionType.HEALTH).SetQuantity(q - 1); 
                    break;
                case "Resistance":
                    this.player.invincible();
                    Invoke("backToNormal", 3f);
                    this.player.getPotion(Potion.potionType.RESISTANCE).SetQuantity(q - 1); 
                    break;

            }
            q--;
            this.quantity.text = "" + q; 
        }

    }


    public void backToNormal()
    {
        this.player.setCanTakeDamage();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player(Clone)").GetComponent<PlayerScript>();
        switch (this.name)
        {
            case "Speed":
                this.quantity = GameObject.Find(this.name + "Quantity").GetComponent<Text>();
                this.quantity.text = this.player.getPotionQuanitity(Potion.potionType.SPEED).ToString();

                break;
            case "Health":
                this.quantity = GameObject.Find(this.name + "Quantity").GetComponent<Text>();
                this.quantity.text = this.player.getPotionQuanitity(Potion.potionType.HEALTH).ToString();
                break;
            case "Resistance":
                this.quantity = GameObject.Find(this.name + "Quantity").GetComponent<Text>();
                this.quantity.text = this.player.getPotionQuanitity(Potion.potionType.RESISTANCE).ToString();
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
