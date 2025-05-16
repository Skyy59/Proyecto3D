using UnityEngine;
using UnityEngine.EventSystems;

public class Collectibles : MonoBehaviour
{
    
    private bool menu;

    public CollectSlot[] collectSlot;




    public void AddItem(string _collectName, int _quantity, Sprite _collectSprite, string collectDescription)
    {
        for (int i = 0; i < collectSlot.Length; i++)
        {
            if (collectSlot[i].isFull == false)
            {
                collectSlot[i].AddItem(_collectName, _quantity, _collectSprite, collectDescription);
                return;
            }

        }
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < collectSlot.Length; i++)
        {
            collectSlot[i].selectedShader.SetActive(false);
            collectSlot[i].thisCollectSelected = false;
        }
    }
}
