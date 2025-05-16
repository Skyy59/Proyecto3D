using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private string _collectName;
    [SerializeField] private int _quantity;
    [SerializeField] private Sprite _sprite;

    [TextArea]
    [SerializeField] private string collectDescription;

    private bool _canGetcollect;

    private Collectibles collectibles;

    void Start()
    {
        collectibles = GameObject.Find("Canvas").GetComponent<Collectibles>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _canGetcollect)
        {
            collectibles.AddItem(_collectName, _quantity, _sprite, collectDescription);
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
