using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string _itemName;
    [SerializeField] private int _quantity;
    [SerializeField] private Sprite _sprite;

    [TextArea]
    [SerializeField] private string itemDescription;

    private bool _canGetitem;

    private Inventory inventory;

    void Start()
    {
        inventory =  GameObject.Find("Canvas").GetComponent<Inventory>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _canGetitem)
        {
            inventory.AddItem(_itemName, _quantity, _sprite, itemDescription);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            _canGetitem = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            _canGetitem = false;
        }
    }
}
