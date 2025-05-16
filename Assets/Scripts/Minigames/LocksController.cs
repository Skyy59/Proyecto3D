using System;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public class LocksController : MonoBehaviour
{
    [SerializeField] private Lock[] locks; 
    [SerializeField] private int[] correctCode = { 3, 1, 4 };



    
    [SerializeField] private BoxCollider trigger;
    [SerializeField] private PuzzleObject puzzleObject;

    [SerializeField] private GameObject uiPanel; 

    public bool puzzleResuelto = false;


    void Update()
    {

   

        if (!puzzleResuelto && CheckSolution())
        {
            puzzleResuelto = true;

            
            
                CerrarEstePuzzle();
                Sex.Instance.sus = true;
            

        }


    }

    
    bool CheckSolution()
    {
        for (int i = 0; i < locks.Length; i++)
        {
            if (!EsNumeroCorrecto(locks[i]))
                return false;
        }
        return true;
    }

    
    bool EsNumeroCorrecto(Lock lockComponent)
    {
        int numeroActual = lockComponent.GetCurrentNumber(); 
        int numeroCorrecto = correctCode[Array.IndexOf(locks, lockComponent)]; 

        return numeroActual == numeroCorrecto;
    }

    
    void CerrarEstePuzzle()
    {
        uiPanel.SetActive(false); 
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ExitPuzzle()
    {
        CerrarEstePuzzle();
    }



}