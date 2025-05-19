using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CollectSlot : MonoBehaviour, IPointerClickHandler
{

    [Header("ITEM DATA")]

    public string collectName;
    public int quantity;
    public Sprite collectSprite;
    public bool isFull;
    public string collectDescription;
    public Sprite emptySprite;

    [Header("ITEM SLOT")]

    [SerializeField] private TMP_Text _quantityText;

    [SerializeField] private Image _collectImage;

    [Header("ITEM DESCRIPTION SLOT")]
    public Image collectDescriptionImage;
    public TMP_Text collectDescriptionNameText;
    public TMP_Text collectDescriptionText;


    public GameObject selectedShader;
    public bool thisCollectSelected;

    private Collectibles collectibles;


    private void Start()
    {
        collectibles = GameObject.Find("Canvas").GetComponent<Collectibles>();
    }


    public void AddCollect(string _collectName, int _quantity, Sprite _collectSprite, string collectDescription)
    {
        this.collectName = _collectName;
        this.quantity = _quantity;
        this.collectSprite = _collectSprite;
        this.collectDescription = collectDescription;
        isFull = true;

        _quantityText.text = quantity.ToString();
        _quantityText.enabled = true;
        _collectImage.sprite = _collectSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }

    public void OnLeftClick()
    {
        collectibles.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisCollectSelected = true;
        collectDescriptionNameText.text = collectName;
        collectDescriptionText.text = collectDescription;
        collectDescriptionImage.sprite = collectSprite;
        if (collectDescriptionImage.sprite == null)
        {
            collectDescriptionImage.sprite = emptySprite;
        }
    }
}
