using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorController : MonoBehaviour
{
    private ColorState _colorState = ColorState.Rainbow;
    public enum ColorState
    {
        White,
        Green =130,
        Blue = 220,
        Purple = 275,
        Yellow = 45,
        Grew = 80,
        Rainbow,
        Transparent
    }

    [SerializeField]
    private bool isRainbow = false;
    private Image spriteRenderer;
    public float rainbowSpeed = 1;

    
    
    private void Start()
    {
        spriteRenderer = GetComponent<Image>();
    }

    private void Update()
    {
        ChangeColor();
        Rainbow();
    }

    private void ChangeColor()
    {
        isRainbow = false;
        switch (_colorState)
        {
            case ColorState.White:
                spriteRenderer.color= Color.white;
                return;
            case ColorState.Rainbow:
                isRainbow = true;
                return;
            case ColorState.Transparent:
                spriteRenderer.color= Color.clear;
                return;
            case ColorState.Blue:
                spriteRenderer.color= Color.blue;
                return;
            case ColorState.Green:
                spriteRenderer.color = Color.green;
                return;
            case ColorState.Purple:
                spriteRenderer.color= Color.magenta;
                return;
            case ColorState.Grew:
                spriteRenderer.color = Color.gray;
                return;
            case ColorState.Yellow:
                spriteRenderer.color= Color.yellow;
                return;
        }
        
    }

    private void Rainbow()
    {
        if (isRainbow)
        {
            var lerp = Mathf.PingPong (Time.time/rainbowSpeed,1);
            spriteRenderer.color = Color.HSVToRGB(lerp, 1, 1, true);
        }
    }
    
    public void ChangeColorState(ColorState colorState)
    {
        _colorState = colorState;
    }
}
