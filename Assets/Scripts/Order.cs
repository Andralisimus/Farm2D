using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    List<Image> productImages;
    List<Text> productCount;

    List<Item> allItems = new List<Item>();
    List<Item> required = new List<Item>();

    void Start()
    {
        productImages = GetComponentsInChildren<Image>().ToList();
        productCount = GetComponentsInChildren<Text>().ToList();

        GetComponentInChildren<Button>().onClick.AddListener(delegate { completeOrder(); });

        allItems.Add(new Item("carrot", "Food/carrot", 1, Item.TYPEPFOOD, 10, 1, 5f));
        allItems.Add(new Item("beet", "Food/beet", 1, Item.TYPEPFOOD, 10, 1, 5f));
        allItems.Add(new Item("pumpkin", "Food/pumpkin", 1, Item.TYPEPFOOD, 10, 1, 5f));
        allItems.Add(new Item("eggplant", "Food/eggplant", 1, Item.TYPEPFOOD, 10, 1, 5f));

        createOrder();
    }

    private void createItemForOrder()
    {
        int productIndex = Random.Range(0, allItems.Count);
        Item product = allItems[productIndex];

        product.count = generateAmount();

        allItems.Remove(product);
        required.Add(product);
    }

    private void createOrder()
    {
        if (Player.currentOrder.Count == 0)
        {
            for (int i = 0; i < generateCount(); i++)
            {
                createItemForOrder();
            }
        }
        else required = Player.currentOrder;



        for (int i = 0; i < required.Count; i++)
        {
            productImages[i + 1].sprite = Resources.Load<Sprite>(required[i].imgUrl);
            productCount[i + 1].text = "x" + required[i].count.ToString();
        }

        Player.currentOrder = required;
    }

    private void completeOrder()
    {
        if (Player.isEnoughItems(required))
        {
            for (int i = 0; i < required.Count; i++)
            {
                Player.removeItemWithName(required[i].name, required[i].count);
            }
            Player.addExp(1);
            Player.currentOrder.Clear();
            Destroy(gameObject);
        }
    }


    private int generateCount()
    {
        if (Player.lvl == 1) return 2;
        if (Player.lvl > 1 && Player.lvl < 4) return Random.Range(1, 3);
        if (Player.lvl >= 4) return 2;

        return 2;
    }

    private int generateAmount()
    {
        if (Player.lvl < 4) return Random.Range(1, 3);
        if (Player.lvl >= 4) return Random.Range(2, 5);

        return 4;
    }
}
