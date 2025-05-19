using UnityEditor;
using UnityEngine;

public class Map : MonoBehaviour
{

    public GameObject map;

    private bool _mapa;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.M) && _mapa)
        {
            Time.timeScale = 1;
            map.SetActive(false);
            _mapa = false;
            
        }
        else if (Input.GetKeyDown(KeyCode.M) && !_mapa)
        {
            Time.timeScale = 0;
            map.SetActive(true);
            _mapa = true;
            
        }



    }
}
