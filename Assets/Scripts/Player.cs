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
        items.Add(getEmptyItem());
    }

    void Update()
    {
        
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
