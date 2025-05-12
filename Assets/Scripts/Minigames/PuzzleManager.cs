using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] puzzlePanels;

    public void ShowPuzzle(int index)
    {
        
        puzzlePanels[index].SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


}
