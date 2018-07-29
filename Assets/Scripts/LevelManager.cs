using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelManager>();
            }
            return instance;
        }
    }

    [SerializeField]
    private string levelName = "My Level";
    [SerializeField]
    public static int levelNumber = 1;
    [SerializeField]
    private Text levelNameText;
    [SerializeField]
    public static int numCustomers = 5;
    private int customersSpawned = 0;
    [SerializeField]
    public static float totalLevelTime = 60.0f;
    [SerializeField]
    private float tLevel = 0.0f;
    [SerializeField]
    private GameObject clockHand;
    private bool canIncreaseLevelTime = true;
    [SerializeField]
    private Customer[] customerSeats;
    [SerializeField]
    private bool canCreateNewCustomer = true;
    private bool levelFinished = false;
    [SerializeField]
    public static float secondsBeforeCustomerArrives = 10.0f;
    private float t = 0.0f;
    [SerializeField]
    private Text customersServedText;
    [SerializeField]
    private GameObject endLevelGUI;

	// Use this for initialization
	void Start()
    {
        if (levelNameText != null)
        {
            levelNameText.text = levelName;
        }
        if (endLevelGUI != null)
        {
            endLevelGUI.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        if (customersSpawned < numCustomers && canCreateNewCustomer)
        {
            if (t < secondsBeforeCustomerArrives)
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
                        customersSpawned++;
                        break;
                    }
                }
            }
        }
        else
        {
            canCreateNewCustomer = false;
            canIncreaseLevelTime = false;
        }

        if (canIncreaseLevelTime)
        {
            if (tLevel < totalLevelTime)
            {
                tLevel += Time.deltaTime;
            }
            else
            {
                tLevel = totalLevelTime;
                canIncreaseLevelTime = false;
                canCreateNewCustomer = false;
            }
        }
        else
        {
            if (levelFinished == false)
            {
                if (IsLevelDone())
                {
                    levelFinished = true;
                    //enable victory screen
                    if (endLevelGUI != null)
                    {
                        StartCoroutine(EndLevel());
                    }
                }
            }
        }

        if (customersServedText != null)
        {
            customersServedText.text = "Served: " + customersSpawned.ToString() + "/" + numCustomers.ToString();
        }
        if (clockHand != null)
        {
            clockHand.transform.rotation = Quaternion.Euler(0.0f, 0.0f, (tLevel / totalLevelTime) * 360.0f * -1.0f);
        }
	}

    private IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(2.0f);
        endLevelGUI.SetActive(true);
    }

    public bool IsLevelDone()
    {
        foreach (Customer cust in customerSeats)
        {
            if (cust.inUse)
            {
                return false;
            }
        }

        return true;
    }

    public void ToNextLevel()
    {
        levelNumber++;
        levelName = "Day " + levelNumber.ToString();
        if (levelNameText != null)
        {
            levelNameText.text = levelName;
        }
        numCustomers += 2;
        customersSpawned = 0;
        totalLevelTime += 10.0f;
        secondsBeforeCustomerArrives -= 0.5f;
        if (secondsBeforeCustomerArrives <= 3.0f)
        {
            secondsBeforeCustomerArrives = 3.0f;
        }
        t = 0.0f;
        tLevel = 0.0f;
        canIncreaseLevelTime = true;
        canCreateNewCustomer = true;
        levelFinished = false;
        endLevelGUI.SetActive(false);
        GameManager.Instance.StartLevel();
    }
}
