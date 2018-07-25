using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Item_UNKNOWN,
    Item_BEAN,
    Item_MILK,
    Item_SUGAR,
    Item_FLAVOR_SHOT,
    Item_TOPPING,
    Item_COFFEE
}

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemType itemType;
    [SerializeField]
    private BeanType beanType;
    [SerializeField]
    private MilkType milkType;
    [SerializeField]
    private FlavorShot flavorShot;
    [SerializeField]
    private ToppingType toppingType;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public BeanType GetBeanType()
    {
        return beanType;
    }

    public void SetBeanType(BeanType bean)
    {
        beanType = bean;
    }

    public MilkType GetMilkType()
    {
        return milkType;
    }

    public void SetMilkType(MilkType milk)
    {
        milkType = milk;
    }

    public FlavorShot GetFlavorShot()
    {
        return flavorShot;
    }

    public void SetFlavorShot(FlavorShot shot)
    {
        flavorShot = shot;
    }

    public ToppingType GetToppingType()
    {
        return toppingType;
    }

    public void SetToppingType(ToppingType topping)
    {
        toppingType = topping;
    }
}
