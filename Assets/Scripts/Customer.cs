using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]
    private int numToppingsToOrder = 0;
    Coffee order;
    [SerializeField]
    BeanType orderBeans;
    [SerializeField]
    MilkType orderMilk;
    [SerializeField]
    int orderSugar;
    [SerializeField]
    FlavorShot orderFlavor;
    [SerializeField]
    List<ToppingType> orderToppings;

	// Use this for initialization
	void Start ()
    {
        order = GameManager.Instance.GenerateOrder(numToppingsToOrder);
        orderBeans = order.beanType;
        orderMilk = order.milkType;
        orderSugar = order.sugarAmount;
        orderFlavor = order.flavor;
        orderToppings = order.toppings;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DetermineOrderCorrectness(Coffee c)
    {
        int mistakes = GameManager.Instance.CompareCoffee(c, order);
        float money = 0.0f;
        switch (mistakes)
        {
            case 0:
                money = GameManager.Instance.DetermineCoffeeAmount(c);
                break;
            case 1:
                money = GameManager.Instance.DetermineCoffeeAmount(c, 0.75f);
                break;
            default:
                money = GameManager.Instance.DetermineCoffeeAmount(c, 0.25f);
                break;
        }
        GameManager.Instance.AlterCurrentMoney(money);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coffee")
        {
            Coffee c = other.gameObject.GetComponent<Coffee>();
            DetermineOrderCorrectness(c);
            Destroy(other.gameObject);
        }
    }
}
