using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeMaker : MonoBehaviour
{
    [SerializeField]
    private GameObject coffeeObject;
    [SerializeField]
    private Vector3 coffeeSpawnPosition;
    private bool isBrewing = false;
    [SerializeField]
    private float secondsToBrew = 3.0f;
    private float t = 0.0f;
    private BeanType nextBeanType;
    [SerializeField]
    private Image fillRing;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if (isBrewing)
        {
            t += Time.deltaTime;
            if (t >= secondsToBrew)
            {
                GameObject obj = Instantiate(coffeeObject, coffeeSpawnPosition, transform.rotation);
                Coffee coffeeComponent = obj.GetComponent<Coffee>();
                coffeeComponent.SetBeanType(nextBeanType);
                isBrewing = false;
                t = 0.0f;
            }
        }
        else
        {
            t = 0.0f;
        }

        if (fillRing != null)
        {
            fillRing.fillAmount = (float)(t / secondsToBrew);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isBrewing)
        {
            if (other.gameObject.tag == "Bean")
            {
                Item item = other.gameObject.GetComponent<Item>();
                if (item != null)
                {
                    //GameObject obj = Instantiate(coffeeObject, coffeeSpawnPosition, transform.rotation);
                    //Coffee coffeeComponent = obj.GetComponent<Coffee>();
                    //coffeeComponent.SetBeanType(item.GetBeanType());
                    nextBeanType = item.GetBeanType();
                    isBrewing = true;
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
