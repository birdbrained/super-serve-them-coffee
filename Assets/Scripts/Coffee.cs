using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BeanType
{
    BT_BASIC,
    BT_KILIMANJARO,
    BT_BLUE_MOUNTAIN,
    BT_MOCHA,
    BT_HOUSE_BLEND,
    BT_HOT_COCOA,
    BT_UNKNOWN
}

public enum MilkType
{
    Milk_NONE,
    Milk_SKIM,
    Milk_WHOLE,
    Milk_CREAM,
    Milk_UNKNOWN
}

public enum FlavorShot
{
    Flavor_NONE,
    Flavor_VANILLA,
    Flavor_MOCHA,
    Flavor_PUMPKIN_SPICE,
    Flavor_UNKNOWN
}

public enum ToppingType
{
    Topping_NONE,
    Topping_WHIPPED_CREAM,
    Topping_SPRINKLES,
    Topping_COCOA_POWDER,
    Topping_CINNAMON,
    Topping_MARSHMALLOW,
    Topping_UNKNOWN
}

public class Coffee : MonoBehaviour
{
    public BeanType beanType;
    public MilkType milkType;
    public int sugarAmount;
    public FlavorShot flavor;
    public List<ToppingType> toppings = new List<ToppingType>();

    public void SetBeanType(BeanType bean)
    {
        beanType = bean;
    }

    public void SetMilkType(MilkType milk)
    {
        milkType = milk;
    }

    public void IncreaseSugar()
    {
        sugarAmount++;
    }

    public void SetSugarAmount(int amount)
    {
        sugarAmount = amount;
    }

    public void SetFlavorShot(FlavorShot shot)
    {
        flavor = shot;
    }

    public void AddTopping(ToppingType topping)
    {
        toppings.Add(topping);
    }
}
