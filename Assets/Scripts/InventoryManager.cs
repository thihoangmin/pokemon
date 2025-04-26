using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



public class InventoryManager : MonoBehaviour
{
    public GameObject inventory;
    public int state;
    public int cooldown;
    public ItemSlot[] ItemSlot;
    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        cooldown = 0;
        inventory.SetActive(false);
    }
    IEnumerator Delay(float time)
    {
        cooldown = 1;
        yield return new WaitForSeconds(time);
        cooldown = 0;
    }
    // Update is called once per frame
    public int  AddItem(string ItemName,int Quantity, Sprite Sprite, string ItemDescription)
    {
        //Debug.Log("item name=" +  ItemName + " quanity " + Quantity );
        for (int i = 0; i < ItemSlot.Length; i++)
        {
            if (ItemSlot[i].IsFull == false && ItemSlot[i].name == name || ItemSlot[i].Quantity == 0 )
            {
                int LeftOverItems = ItemSlot[i].AddItem(ItemName, Quantity, Sprite,ItemDescription);
                Debug.Log(LeftOverItems);
                if (LeftOverItems > 0)
                {
                    LeftOverItems= AddItem(ItemName, LeftOverItems, Sprite,ItemDescription);
                }
                return LeftOverItems;
            }
        }
        return Quantity;
    }
    public void DeselectAllSlots()
    {
        for (int i = 0; i < ItemSlot.Length; i++)
        {
            ItemSlot[i].SelectedShader.SetActive(false);
            ItemSlot[i].ThisItemSelected = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            if ( (cooldown == 0))
            {
                if (state == 0)
                {
                    StartCoroutine(Delay(0.5f));
                    inventory.SetActive(true);
                    state = 1;
                }
                else
                {
                    StartCoroutine(Delay(0.5f));
                    inventory.SetActive(false);
                    state = 0;
                }



            }



            
            

    }
}
