using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static List<Item> items = new List<Item>();
    public static int lvl = 3;
    public static float lvlProgress = 0;
    public static float[] expMultiplier = new float[8];
    public static List<List<Item>> currentOrders = new List<List<Item>>();
    public static int money = 200;

    void Start()
    {
        currentOrders.Add(new List<Item>());
        currentOrders.Add(new List<Item>());

        items.Add(getEmptyItem());
        items.Add(new Item("plow", "Tools/Plow", 0, Item.TYPEPLOW, 0, 0, 0f));
        items.Add(getEmptyItem());
        items.Add(getEmptyItem());
        items.Add(getEmptyItem());
        items.Add(getEmptyItem());
        items.Add(getEmptyItem());


        expMultiplier[1] = 0.04f;
        expMultiplier[2] = 0.03f;
        expMultiplier[3] = 0.03f;
        expMultiplier[4] = 0.02f;
        expMultiplier[5] = 0.02f;
        expMultiplier[6] = 0.01f;
        expMultiplier[7] = 0.01f;
    }

    public static void addExp(int exp)
    {
        lvlProgress += exp * expMultiplier[lvl];

        if (lvlProgress >= 1)
        {
            lvl++;
            lvlProgress = 0;
        }
    }

    public static bool isEnoughItems(List<Item> required)
    {
        int itemsToComplete = required.Count;
        for (int i = 0; i < required.Count; i++)
        {
            foreach(Item item in items)
            {
                if(item.name == required[i].name)
                {
                    if(item.count >= required[i].count)
                    {
                        itemsToComplete--;
                    }
                }
            }
        }
        if (itemsToComplete == 0) return true;
        else return false;
    }

    public static void removeItemWithName(string name, int count)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].name == name)
            {
                if (items[i].count <= count)
                {
                    items[i] = getEmptyItem();
                } else
                {
                    items[i].count -= count;
                }
            }
        }
    }

    public static Item getHandItem()
    {
        return new Item(items[0].name, items[0].imgUrl, items[0].count, items[0].type, items[0].price, items[0].lvlWhenUnlock, items[0].timeToGrow);
    }

    public static Item getEmptyItem()
    {
        return new Item("empty", "Food/empty", 0, 0, 0, 0, 0);
    }

    public static void removeItem()
    {
        if (items[0].count == 1)
        {
            items[0] = getEmptyItem();
        } else
        {
            items[0].count -= 1;
        }
    }

    public static void checkIfItemExists(Item item)
    {
        bool exist = false;
        for (int i = 0; i < items.Count; i++)
        {
            if (item.name == items[i].name)
            {
                items[i].count += item.count;
                exist = true;
                break;
            }
        }
        if (!exist)
        {
            addItemToInventory(item);
        }
    }

    private static void addItemToInventory(Item item)
    {
        bool added = false;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].name == "empty")
            {
                items[i] = item;
                added = true;
                break;
            }
        }
        if (!added)
        {
            items.Add(item);
        }
    }
}
