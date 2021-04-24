using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static List<Item> items = new List<Item>();

    void Start()
    {
        Item item = new Item("carrot", "Food/carrot", 1, Item.TYPEPFOOD, 10, 1, 5f);
        items.Add(item);
        items.Add(new Item("plow", "Tools/Plow", 0, Item.TYPEPLOW, 0, 0, 0f));
        items.Add(new Item("beet", "Food/beet", 3, Item.TYPEPFOOD, 10, 1, 5f));
        items.Add(new Item("pumpkin", "Food/pumpkin", 3, Item.TYPEPFOOD, 10, 1, 5f));
        items.Add(getEmptyItem());
        items.Add(getEmptyItem());
        items.Add(getEmptyItem());
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
