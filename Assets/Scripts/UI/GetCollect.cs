using UnityEngine;

public class GetCollect : MonoBehaviour
{
    private bool _canGetcollect;

    public Sex sex;
    public Collectable collectToGive;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _canGetcollect)
        {
            sex.AssignCollectData(collectToGive);
            Collectibles.collectibles.AddCollect(collectToGive);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            _canGetcollect = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            _canGetcollect = false;
        }
    }
}
