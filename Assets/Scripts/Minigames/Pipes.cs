using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Pipes : MonoBehaviour
{
    public RectTransform imageRotate;
    public float rotationamount = 90f;

    public void Rotate()
    {
        if (imageRotate != null)
        {
            imageRotate.Rotate(0f, 0f, rotationamount);
        }
    }
}
