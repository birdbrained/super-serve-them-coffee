using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteManager : MonoBehaviour
{
    private static PaletteManager instance;
    public static PaletteManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PaletteManager>();
            }
            return instance;
        }
    }

    private int currentPaletteIndex = 0;
    private Color[] currentPalette = new Color[4];
    public Color[] CurrentPalette
    {
        get
        {
            return currentPalette;
        }
    }

    /*
     * index: color of object
     * 0: Darkest color, used for protag, coffee base, table base
     * 1: Lighter color, highlight for coffee, base for items
     * 2: Even lighter, highlight for items
     * 3: Lightest color, used for brightest highlights
     */

    /*Color[] paletteMild = new Color[]
    {
        new Color(47.0f/255.0f, 14.0f/255.0f, 0.0f, 1.0f),
        new Color(71.0f/255.0f, 44.0f/255.0f, 33.0f/255.0f, 1.0f),
        new Color(141.0f/255.0f, 75.0f/255.0f, 47.0f/255.0f, 1.0f),
        new Color(180.0f/255.0f, 106.0f/255.0f, 74.0f/255.0f, 1.0f)
    };

    Color[] paletteBold = new Color[]
    {
        new Color(34.0f/255.0f, 12.0f/255.0f, 3.0f/255.0f, 1.0f),
        new Color(54.0f/255.0f, 30.0f/255.0f, 20.0f/255.0f, 1.0f),
        new Color(71.0f/255.0f, 45.0f/255.0f, 34.0f/255.0f, 1.0f),
        new Color(98.0f/255.0f, 68.0f/255.0f, 55.0f/255.0f, 1.0f)
    };*/

    Color[][] palettes = new Color[4][]
    {
        new Color[4]
        {
            new Color(47.0f/255.0f, 14.0f/255.0f, 0.0f, 1.0f),
            new Color(71.0f/255.0f, 44.0f/255.0f, 33.0f/255.0f, 1.0f),
            new Color(141.0f/255.0f, 75.0f/255.0f, 47.0f/255.0f, 1.0f),
            new Color(180.0f/255.0f, 106.0f/255.0f, 74.0f/255.0f, 1.0f)
        },
        new Color[4]
        {
            new Color(34.0f/255.0f, 12.0f/255.0f, 3.0f/255.0f, 1.0f),
            new Color(54.0f/255.0f, 30.0f/255.0f, 20.0f/255.0f, 1.0f),
            new Color(71.0f/255.0f, 45.0f/255.0f, 34.0f/255.0f, 1.0f),
            new Color(98.0f/255.0f, 68.0f/255.0f, 55.0f/255.0f, 1.0f)
        },
        new Color[4]
        {
            new Color(173.0f/255.0f, 96.0f/255.0f, 63.0f/255.0f, 1.0f),
            new Color(193.0f/255.0f, 125.0f/255.0f, 97.0f/255.0f, 1.0f),
            new Color(229.0f/255.0f, 180.0f/255.0f, 160.0f/255.0f, 1.0f),
            new Color(186.0f/255.0f, 145.0f/255.0f, 128.0f/255.0f, 1.0f)
        },
        new Color[4]
        {
            new Color(5.0f/255.0f, 0.0f, 60.0f/255.0f, 1.0f),
            new Color(0.0f, 12.0f/255.0f, 139.0f/255.0f, 1.0f),
            new Color(65.0f/255.0f, 87.0f/255.0f, 191.0f/255.0f, 1.0f),
            new Color(122.0f/255.0f, 143.0f/255.0f, 1.0f, 1.0f)
        }
    };

    // Use this for initialization
    void Start ()
    {
        //currentPalette = paletteMild;
        for (int j = 0; j < palettes[currentPaletteIndex].Length; j++)
        {
            currentPalette[j] = palettes[currentPaletteIndex][j];
        }
        UpdateSpriteColors();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void UpdateSpriteColors()
    {
        ColorableSprite[] sprites = FindObjectsOfType<ColorableSprite>();
        foreach (ColorableSprite cs in sprites)
        {
            cs.UpdateColor();
        }

        ColorableMaterial[] mats = FindObjectsOfType<ColorableMaterial>();
        foreach (ColorableMaterial cm in mats)
        {
            cm.UpdateColor();
        }

        ColorableLight[] lights = FindObjectsOfType<ColorableLight>();
        foreach (ColorableLight cl in lights)
        {
            cl.UpdateColor();
        }
    }

    public void ChangePalette(int incrementOrDecrement)
    {
        /*switch (paletteIndex)
        {
            case 1:     //Bold palette
                currentPalette = paletteBold;
                break;
            default:    //default to Mild palette, also has paletteIndex of 0
                currentPalette = paletteMild;
                break;
        }*/
        if (incrementOrDecrement >= 0)
        {
            currentPaletteIndex++;
            if (currentPaletteIndex >= currentPalette.Length)
            {
                currentPaletteIndex = currentPalette.Length - 1;
            }
        }
        else
        {
            currentPaletteIndex--;
            if (currentPaletteIndex < 0)
            {
                currentPaletteIndex = 0;
            }
        }

        for (int j = 0; j < palettes[currentPaletteIndex].Length; j++)
        {
            currentPalette[j] = palettes[currentPaletteIndex][j];
        }
        UpdateSpriteColors();
    }
}
