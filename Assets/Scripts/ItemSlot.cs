using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;


public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    // ItemData //
    public string ItemName;
    public int Quantity;
    public Sprite ItemSprite;
    public bool IsFull;
    public string ItemDescription;

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
    public void AddItem(string ItemName, int Quantity, Sprite Sprite)
    {
        this.ItemName = ItemName;
        this.Quantity = Quantity;
        this.ItemSprite = Sprite;
        IsFull = true;

        QuantityText.text = Quantity.ToString();
        QuantityText.enabled = true;
        ItemImage.sprite = ItemSprite;
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
    }
    public void OnRightClick()
    {

    }

}
