using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{
    private Vector3 _lastCheckpos;
    [SerializeField] private CharacterController _cctr;
    AIController _controller;

    private void Start()
    {
        _cctr = GetComponent<CharacterController>();
        _lastCheckpos = transform.position;
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Respawn();
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            _lastCheckpos = other.transform.position;
        }
    }

    public void Respawn()
    {
        
        _cctr.enabled = false;
        transform.position = _lastCheckpos;
        _cctr.enabled = true;
    }

    

}
