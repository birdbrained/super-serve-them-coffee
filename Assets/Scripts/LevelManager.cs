using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private string levelName = "My Level";
    [SerializeField]
    private Text levelNameText;
    [SerializeField]
    private int numCustomers = 10;
    [SerializeField]
    private Customer[] customerSeats;
    [SerializeField]
    private bool levelFinished = false;
    [SerializeField]
    private float secondsBeforeCustomerArrives = 5.0f;
    private float t = 0.0f;

	// Use this for initialization
	void Start()
    {
        if (levelNameText != null)
        {
            levelNameText.text = levelName;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
		if (t <= secondsBeforeCustomerArrives)
        {
            t += Time.deltaTime;
        }
        else
        {
            t = 0.0f;
            for (int i = 0; i < customerSeats.Length; i++)
            {
                if (!customerSeats[i].inUse)
                {
                    customerSeats[i].StartOrder();
                    break;
                }
            }
        }
	}
}
