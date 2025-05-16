using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject inventory;
    public GameObject collectibles;
    public GameObject invbutton;
    public GameObject collebutton;

    private bool menu;

    public ItemSlot[] itemSlot;

    void Start()
    {
        
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


    public void AddItem(string _itemName, int _quantity, Sprite _itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(_itemName, _quantity, _itemSprite, itemDescription);
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
