using UnityEngine;

public class ChangeIC : MonoBehaviour
{

    public GameObject inventory;
    public GameObject collect;
    
    
    void Start()
    {
        
    }

    public void ChangeToCollect()
    {
        inventory.SetActive(false);
        collect.SetActive(true);
    }

    public void ChangeToInvent()
    {
        inventory.SetActive(true);
        collect.SetActive(false);
    }
}
