using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    [Header("ITEM DATA")]

    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;

    [Header("ITEM SLOT")]

    [SerializeField] private TMP_Text _quantityText;

    [SerializeField] private Image _itemImage;

    [Header("ITEM DESCRIPTION SLOT")]
    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionNameText;
    public TMP_Text itemDescriptionText;


    public GameObject selectedShader;
    public bool thisItemSelected;

    private Inventory inventory;


    private void Start()
    {
        inventory = GameObject.Find("Canvas").GetComponent<Inventory>();
    }


    public void AddItem(string _itemName, int _quantity, Sprite _itemSprite, string itemDescription)
    {
        this.itemName = _itemName;
        this.quantity = _quantity;
        this.itemSprite = _itemSprite;
        this.itemDescription = itemDescription;
        isFull = true;

        _quantityText.text = quantity.ToString();
        _quantityText.enabled = true;
        _itemImage.sprite = _itemSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }

    public void OnLeftClick()
    {
        inventory.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
        itemDescriptionNameText.text = itemName;
        itemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;
        if(itemDescriptionImage.sprite == null)
        {
            itemDescriptionImage.sprite = emptySprite;
        }
    }
}
