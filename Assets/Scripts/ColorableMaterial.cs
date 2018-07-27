using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorableMaterial : MonoBehaviour
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
    private Renderer rend;
    private Material copyMaterial;
    private Color myColor;

	// Use this for initialization
	void Start ()
    {
        rend = GetComponent<Renderer>();
        copyMaterial = new Material(rend.material);
        rend.material = copyMaterial;
        UpdateColor();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void UpdateColor()
    {
        myColor = PaletteManager.Instance.CurrentPalette[paletteIndex];
        if (copyMaterial != null)
        {
            copyMaterial.color = myColor;
        }
    }
}
