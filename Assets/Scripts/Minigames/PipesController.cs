using UnityEngine;

[System.Serializable]
public class ValidRotationsButtons
{
    public int[] rotaciones; // Lista de rotaciones válidas para este botón (en grados, eje Z)
}

public class PipesController : MonoBehaviour
{
    [Header("Configuración")]
    public float tolerancia = 5f;
    public bool cerrarPuzzleAlResolver = true;

    private bool puzzleResuelto = false;
    [SerializeField] private BoxCollider trigger;
    [SerializeField] private PuzzleObject puzzleObject;

    [Header("Botones del puzzle (en Canvas)")]
    public RectTransform[] botones; 

    [Header("Rotaciones válidas por botón")]
    public ValidRotationsButtons[] rotacionesObjetivo; // Rotaciones correctas por botón

 

    void Update()
    {
        if (!puzzleResuelto && CheckSolution())
        {
            puzzleResuelto = true;

            if (cerrarPuzzleAlResolver && puzzleResuelto == true)
            {
                CerrarEstePuzzle();
                Destroy(trigger);
                puzzleObject.playerInRange = false;
            }
                
        }
    }

    bool CheckSolution()
    {
        for (int i = 0; i < botones.Length; i++)
        {
            if (!EsRotacionCorrecta(botones[i], rotacionesObjetivo[i]))
                return false;
        }
        return true;
    }

    bool EsRotacionCorrecta(RectTransform boton, ValidRotationsButtons rotacionesValidas)
    {
        float rotacionActual = boton.eulerAngles.z;

        foreach (int rotacionObjetivo in rotacionesValidas.rotaciones)
        {
            float diferencia = Mathf.Abs(Mathf.DeltaAngle(rotacionActual, rotacionObjetivo));
            if (diferencia <= tolerancia)
                return true;
        }

        return false;
    }

    void CerrarEstePuzzle()
    {
        gameObject.SetActive(false); // Cierra el panel del puzzle actual
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


}