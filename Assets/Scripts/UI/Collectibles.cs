using UnityEngine;
using UnityEngine.EventSystems;

public class Collectibles : MonoBehaviour
{
    public static Collectibles collectibles;


    private bool menu;

    public CollectSlot[] collectSlot;

    public Collectable collect;



    private void Awake()
    {
        collectibles = this;
    }

    public void AddCollect(Collectable _tuVieja)
    {
        for (int i = 0; i < collectSlot.Length; i++)
        {
            if (collectSlot[i].isFull == false)
            {
                collectSlot[i].AddCollect(_tuVieja.collectName, _tuVieja.quantity, _tuVieja.sprite, _tuVieja.collectDescription);
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
