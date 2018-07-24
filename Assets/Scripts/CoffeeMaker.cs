using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMaker : MonoBehaviour
{
    [SerializeField]
    private GameObject coffeeObject;
    [SerializeField]
    private Vector3 coffeeSpawnPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bean")
        {
            Item item = other.gameObject.GetComponent<Item>();
            if (item != null)
            {
                GameObject obj = Instantiate(coffeeObject, coffeeSpawnPosition, transform.rotation);
                Coffee coffeeComponent = obj.GetComponent<Coffee>();
                coffeeComponent.SetBeanType(item.GetBeanType());
                Destroy(other.gameObject);
            }
        }
    }
}
