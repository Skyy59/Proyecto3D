using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sex : MonoBehaviour
{

    [SerializeField] private Image image;
    public bool sus;
    public float timer;
   
    public Sprite defaultImage;

    public AnimationCurve curve;

    public TextMeshProUGUI text;

   

    private void Awake()
    {
        

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

        timer += Time.deltaTime / curve.keys[curve.keys.Length-1].time;

        image.color = Color.Lerp(Color.white, Color.clear, curve.Evaluate(timer));

        if(text)
        text.color = Color.Lerp(Color.white, Color.clear, curve.Evaluate(timer));

        if (timer >= 1)
        {
            timer = 0;
            sus = false;

            if (text)
            {
                text.text = "";
                text.color = Color.clear;
            }
            image.color = Color.clear;
            
        }
    }

    public void AsingItemData(Item _tumadre = null)
    {

        if (_tumadre)
        {
            if (text) text.text = "Has conseguido " + _tumadre.itemName;
            image.sprite = _tumadre.sprite;
        }
        else
        {
            image.sprite = defaultImage;
        }
        sus = true;
        timer = 0;
    }

    public void AssignCollectData(Collectable _tuVieja = null)
    {
        if (_tuVieja)
        {
            if (text) text.text = "Has conseguido " + _tuVieja.collectName;
            image.sprite = _tuVieja.sprite;
        }
        else
        {
            image.sprite = defaultImage;
        }
        sus = true;
        timer = 0;
    }
}
