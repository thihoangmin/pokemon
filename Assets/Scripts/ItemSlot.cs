using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using JetBrains.Annotations;


public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    // ItemData //
    public string ItemName;
    public int Quantity;
    public Sprite ItemSprite;
    public bool IsFull;
    public string ItemDescription;
    public Sprite EmptySprite;
    [SerializeField]
    private Dictionary<string, int> MaxNumberOfItems = new Dictionary<string, int>()
    {
        {"potion",5 },
        {"Coin",999 },
        {"Fish",30 },
        {"Key",1 },
    };
    // Itemslot //
    [SerializeField]
    private TMP_Text QuantityText;
    [SerializeField]
    private Image ItemImage;

    public GameObject SelectedShader;
    public bool ThisItemSelected;
    public InventoryManager InventoryManager;
    // ItemDescription//
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;

    public void Start()
    {
        InventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }
    public int AddItem(string ItemName, int Quantity, Sprite Sprite, string ItemDescription)
    {
        //Check if inventory is full
        if (IsFull)
            return Quantity;
        //Update name,sprite,descriptiom
        this.ItemName = ItemName;
        this.ItemSprite = Sprite;
        ItemImage.sprite = Sprite;
        this.ItemDescription = ItemDescription;
        //Update quantity, return leftovers base on max items
        this.Quantity += Quantity;
        Debug.Log(MaxNumberOfItems[ItemName]);
        if (this.Quantity >= MaxNumberOfItems[ItemName])
        {
            QuantityText.text = MaxNumberOfItems[ItemName].ToString();
            QuantityText.enabled = true;
            IsFull = true;


            int ExtraItems = this.Quantity - MaxNumberOfItems[ItemName]; 
            this.Quantity = MaxNumberOfItems[ItemName];
            return ExtraItems;
        }

        QuantityText.text = this.Quantity.ToString();
        QuantityText.enabled = true;

        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }
    public void OnLeftClick()
    {
        InventoryManager.DeselectAllSlots();
        SelectedShader.SetActive(true);
        ThisItemSelected = true;
        ItemDescriptionNameText.text = ItemName;
        ItemDescriptionText.text = ItemDescription;
        ItemDescriptionImage.sprite = ItemSprite;
        if (ItemDescriptionImage.sprite == null)
        {
            ItemDescriptionImage.sprite = EmptySprite;
        }
    }
    public void OnRightClick()
    {

    }

}
