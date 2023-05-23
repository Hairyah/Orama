using UnityEngine;
using UnityEngine.UI;

public class Clignotement : MonoBehaviour
{
    public Color startColor;
    public Color endColor;
    [Range(0, 10)]
    public float speed = 1;

    Image imgComp;

    void Awake()
    {
        imgComp = GetComponent<Image>();
    }

    void Update()
    {
        imgComp.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
    }
}
