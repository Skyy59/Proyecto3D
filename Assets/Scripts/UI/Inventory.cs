using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;


    public GameObject inventory;
    public GameObject collectibles;
    public GameObject invbutton;
    public GameObject collebutton;

    public Item[] startitems;

    private bool menu;

    public ItemSlot[] itemSlot;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < startitems.Length; i++)
        {
            AddItem(startitems[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && menu )
        {
            Time.timeScale = 1;
            inventory.SetActive(false);
            collectibles.SetActive(false);
            invbutton.SetActive(false);
            collebutton.SetActive(false);
            menu = false;
            Cursor.visible = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && !menu)
        {
            Time.timeScale = 0;
            inventory.SetActive(true);
            invbutton.SetActive(true);
            collebutton.SetActive(true);
            menu = true;
            Cursor.visible = true;
        }
    }


    public void AddItem(Item _tuMadre)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(_tuMadre.itemName, _tuMadre.quantity, _tuMadre.sprite, _tuMadre.itemDescription);
                return;
            }

        }
    }

    public void DeselectAllSlots()
    {
        for(int i = 0;i < itemSlot.Length;i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}
