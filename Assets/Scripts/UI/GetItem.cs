using UnityEngine;

public class GetItem : MonoBehaviour
{
    private bool _canGetitem;

    public Sex sex;
    public Item itemToGive;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _canGetitem)
        {
            sex.AsingItemData(itemToGive);
            Inventory.Instance.AddItem(itemToGive);
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
