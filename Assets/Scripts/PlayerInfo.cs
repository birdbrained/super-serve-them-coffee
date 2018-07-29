using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private static PlayerInfo instance;
    public static PlayerInfo Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerInfo>();
            }
            return instance;
        }
    }
    public string shopName = "Sweet Joint";

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateShopName(string name)
    {
        shopName = name;
    }
}
