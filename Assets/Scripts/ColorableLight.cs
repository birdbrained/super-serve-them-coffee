using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorableLight : MonoBehaviour
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
    private Light light;
    private Color myColor;

    // Use this for initialization
    void Start ()
    {
        light = GetComponent<Light>();
        UpdateColor();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateColor()
    {
        myColor = PaletteManager.Instance.CurrentPalette[paletteIndex];
        if (light != null)
        {
            light.color = myColor;
        }
    }
}
