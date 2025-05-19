using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] puzzlePanels;

    public void ShowPuzzle(int index)
    {
        GameObject _puzzle = puzzlePanels[index];
        LocksController _locks = _puzzle.GetComponent<LocksController>();
        
        if (_locks)
        {
            if (_locks.puzzleResuelto)
            {
               

                return;
            }

        }
     


        puzzlePanels[index].SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


}
