using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public int id;

    List<Image> productImages;
    List<Text> productCount;

    List<Item> allItems = new List<Item>();
    List<Item> required = new List<Item>();

    private Text reward;
    private int moneyToRecive;
    private int expToRecive;

    void Start()
    {
        reward = GetComponentsInChildren<Text>()[0];

        productImages = GetComponentsInChildren<Image>().ToList();
        productCount = GetComponentsInChildren<Text>().ToList();

        GetComponentInChildren<Button>().onClick.AddListener(delegate { completeOrder(); });

        if (Player.lvl > 0) allItems.Add(new Item("carrot", "Food/carrot", 1, Item.TYPEPFOOD, 10, 1, 5f));
        if (Player.lvl > 1) allItems.Add(new Item("beet", "Food/beet", 1, Item.TYPEPFOOD, 10, 2, 5f));
        if (Player.lvl > 2) allItems.Add(new Item("pumpkin", "Food/pumpkin", 1, Item.TYPEPFOOD, 10, 3, 5f));
        if (Player.lvl > 3) allItems.Add(new Item("eggplant", "Food/eggplant", 1, Item.TYPEPFOOD, 10, 4, 5f));

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
        if (Player.currentOrders[id].Count == 0)
        {
            for (int i = 0; i < generateCount(); i++)
            {
                createItemForOrder();
            }
        }
        else required = Player.currentOrders[id];



        for (int i = 0; i < required.Count; i++)
        {
            productImages[i + 1].sprite = Resources.Load<Sprite>(required[i].imgUrl);
            productCount[i + 2].text = "x" + required[i].count.ToString();
        }

        generateReward();
        Player.currentOrders[id] = required;
    }

    private void completeOrder()
    {
        if (Player.isEnoughItems(required))
        {
            for (int i = 0; i < required.Count; i++)
            {
                Player.removeItemWithName(required[i].name, required[i].count);
            }
            Player.addExp(expToRecive);
            Player.money += moneyToRecive;
            Player.currentOrders[id].Clear();
            Destroy(gameObject);
        }
    }

    private void generateReward()
    {
        switch (Player.lvl)
        {
            case 1:
                moneyToRecive = Random.Range(6, 15); //6..14
                expToRecive = Random.Range(1, 3); //1..2
                break;
            case 2:
                moneyToRecive = Random.Range(9, 21); //9..20
                expToRecive = Random.Range(1, 5); //1..4
                break;
            default:
                moneyToRecive = Random.Range(20, 35); //20..34
                expToRecive = Random.Range(4, 8); //4..7
                break;    
        }
        reward.text = $"You will recive {expToRecive} exp and {moneyToRecive}$";
    }

    private int generateCount()
    {
        if (Player.lvl == 1) return 1;
        if (Player.lvl == 2) return Random.Range(1, 3); //1..2
        if (Player.lvl == 3) return Random.Range(1, 3); //1..2
        if (Player.lvl == 4) return Random.Range(2, 4); //2..3

        return 3;
    }

    private int generateAmount()
    {
        if (Player.lvl == 1) return Random.Range(1, 3); //1..2
        if (Player.lvl == 2) return Random.Range(1, 3); //1..2
        if (Player.lvl == 3) return Random.Range(1, 4); //1..3
        if (Player.lvl == 4) return Random.Range(2, 4); //2..3

        return 4;
    }
}
