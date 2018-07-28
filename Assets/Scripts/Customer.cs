using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    private SpriteRenderer sr;

    public bool inUse = false;
    [SerializeField]
    private GameObject customerObject;
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

    private string[] startOrderQuips =
    {
        "Hello, I would like a ",
        "I'm going to order a ",
        "May I have a ",
        "How's your day been? I'll have a ",
        "Hey, y'all. Gimme a ",
        "Give me the ",
        "I'll have a ",
        "I'm game for a ",
        "Gimme a "
    };
    [SerializeField]
    private string orderQuip = "";
    [SerializeField]
    private Text orderQuipText;

	// Use this for initialization
	void Start ()
    {
        sr = GetComponent<SpriteRenderer>();
        customerObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (orderQuipText != null)
        {
            orderQuipText.text = orderQuip;
        }
	}

    private string CreateOrderString()
    {
        string quip = "";
        int rando = startOrderQuips.Length - 1;
        quip = startOrderQuips[rando];

        switch (orderBeans)
        {
            case BeanType.BT_BASIC:
                quip += "Basic Coffee";
                break;
            case BeanType.BT_BLUE_MOUNTAIN:
                quip += "Blue Mountain";
                break;
            case BeanType.BT_HOT_COCOA:
                quip += "Hot Chocolate";
                break;
            case BeanType.BT_HOUSE_BLEND:
                quip += "House Blend";
                break;
            case BeanType.BT_KILIMANJARO:
                quip += "Kilimanjaro";
                break;
            case BeanType.BT_MOCHA:
                quip += "Mocha Coffee";
                break;
            default:
                quip += "fuck! this shouldn't have happened";
                break;
        }

        switch (orderMilk)
        {
            case MilkType.Milk_CREAM:
                quip += " with cream";
                break;
            case MilkType.Milk_NONE:
                //quip += "without milk";
                break;
            case MilkType.Milk_SKIM:
                quip += " with skim milk";
                break;
            case MilkType.Milk_WHOLE:
                quip += " with whole milk";
                break;
            default:
                quip += " shit! milk type is unknown...";
                break;
        }

        if (orderMilk == MilkType.Milk_NONE)
        {
            quip += " with ";
        }
        else
        {
            quip += " and ";
        }

        switch (orderSugar)
        {
            case 1:
                quip +=  "one sugar";
                break;
            case 2:
                quip += "two sugars";
                break;
            default:
                quip += "no sugar";
                break;
        }

        switch (orderFlavor)
        {
            case FlavorShot.Flavor_MOCHA:
                quip += ", with Mocha Flavor";
                break;
            case FlavorShot.Flavor_NONE:
                break;
            case FlavorShot.Flavor_PUMPKIN_SPICE:
                quip += ", with Pumpkin Spice Flavor";
                break;
            case FlavorShot.Flavor_VANILLA:
                quip += ", with Vanilla Flavor";
                break;
            default:
                quip += ", crud! unknown flavor type...";
                break;
        }

        if (numToppingsToOrder == 0)
        {
            //if (orderToppings[0] == ToppingType.Topping_NONE)
            //{
                quip += ", no toppings";
            //}
        }
        else 
        {
            quip += ", topped with ";
            if (numToppingsToOrder == 1)
            {
                quip += GameManager.Instance.ToppingTypeToString(orderToppings[0]);
            }
            else if (numToppingsToOrder == 2)
            {
                quip += GameManager.Instance.ToppingTypeToString(orderToppings[0]) + " and " + GameManager.Instance.ToppingTypeToString(orderToppings[1]);
            }
        }

        int rand = Random.Range(0, 2);
        if (rand == 1)
        {
            quip += ".";
        }
        else
        {
            quip += ", please.";
        }

        return quip;
    }

    public void StartOrder()
    {
        numToppingsToOrder = Random.Range(0, 3);
        order = GameManager.Instance.GenerateOrder(numToppingsToOrder);
        orderBeans = order.beanType;
        orderMilk = order.milkType;
        orderSugar = order.sugarAmount;
        orderFlavor = order.flavor;
        orderToppings = order.toppings;
        numToppingsToOrder = orderToppings.Count;
        while (orderToppings.Contains(ToppingType.Topping_NONE))
        {
            orderToppings.Remove(ToppingType.Topping_NONE);
            numToppingsToOrder = orderToppings.Count;
        }
        inUse = true;
        customerObject.SetActive(true);
        orderQuip = CreateOrderString();
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
        if (inUse)
        {
            if (other.gameObject.tag == "Coffee")
            {
                Coffee c = other.gameObject.GetComponent<Coffee>();
                DetermineOrderCorrectness(c);
                Destroy(other.gameObject);
                inUse = false;
                customerObject.SetActive(false);
            }
        }
    }
}
