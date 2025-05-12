using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    public int puzzleIndex;
    public bool playerInRange = false;
    [SerializeField] private PuzzleManager puzzleManager;

    void Start()
    {
        
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            puzzleManager.ShowPuzzle(puzzleIndex);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}
