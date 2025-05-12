using UnityEngine;

public class Taquillas : MonoBehaviour
{

    [SerializeField] Transform _ptr;
    [SerializeField] Transform _ttr;
    [SerializeField] Transform _cameras;
    [SerializeField] private GameObject player;
    [SerializeField] private AIController _AIctr;
    public bool isOnTrigger;
    public bool isVisible;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isVisible = true;
        _AIctr.SetPlayerHidden(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnTrigger == true && Input.GetKeyDown(KeyCode.Space))
        {

            CheckOnThis();

        }

    }


    private void OnTriggerStay(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            isOnTrigger = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            isOnTrigger = false;
        }
    }

    void CheckOnThis()
    {

        isVisible = !isVisible;
        player.SetActive(isVisible);

        if (isVisible)
        {
            _AIctr.SetPlayerHidden(false); // Jugador visible, la IA puede perseguirlo
        }
        else
        {
            _AIctr.SetPlayerHidden(true); // Jugador oculto, la IA ya no lo detecta
        }

    }
}
