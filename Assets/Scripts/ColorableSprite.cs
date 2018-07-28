using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorableSprite : MonoBehaviour
{
    [SerializeField]
    private int paletteIndex = 0;
    public int PaletteIndex
    {
        get
        {
            return paletteIndex;
        }
    }
    private SpriteRenderer sr;
    private Color myColor;

    // Use this for initialization
    void Start ()
    {
        sr = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    private void OnEnable()
    {
        UpdateColor();
    }

    // Update is called once per frame
    void Update ()
    {
        
    }

    public void UpdateColor()
    {
        myColor = PaletteManager.Instance.CurrentPalette[paletteIndex];
        if (sr != null)
        {
            sr.color = myColor;
        }
    }
}
