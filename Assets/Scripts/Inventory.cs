using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<GameObject> inventory;

    public Inventory()
    {
        this.inventory = new List<GameObject>();

    }

    public void addInventory(GameObject item)
    {
        inventory.Add(item);
    }
    public List<GameObject> getInventory()
    {
        return this.inventory;
    }

}
