using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string ItemName;

    [SerializeField]
    private int Quantity;

    [SerializeField]
    private Sprite Sprite;

    [TextArea]
    [SerializeField]
    private string ItemDescription;

    private InventoryManager inventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int LeftOverItems = inventoryManager.AddItem(ItemName, Quantity, Sprite, ItemDescription);
            if (LeftOverItems <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                Quantity = LeftOverItems;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
