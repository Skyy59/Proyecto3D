using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Sex : MonoBehaviour
{
    public static Sex Instance;

    [SerializeField] private Image image;
    public bool sus;
    public float timer;
    public float duration = 1f;

    private void Awake()
    {
        Instance = this;

    }


    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Flashbang();
    }

    private void Flashbang()
    {
        if (!sus) return;

        timer += Time.deltaTime / duration;

        image.color = Color.Lerp(Color.white, Color.clear, timer);

        if (timer >= 1)
        {
            timer = 0;
            sus = false;
        }
    }
}
