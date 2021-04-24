using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    List<Image> productImages;
    List<Text> productCount;

    List<Item> required = new List<Item>();

    void Start()
    {
        productImages = GetComponentsInChildren<Image>().ToList();
        productCount = GetComponentsInChildren<Text>().ToList();

        GetComponentInChildren<Button>().onClick.AddListener(delegate { completeOrder(); });

        createOrder();
    }

    private void createOrder()
    {
        required.Add(new Item("carrot", "Food/carrot", 1, Item.TYPEPFOOD, 10, 1, 5f));
        required.Add(new Item("beet", "Food/beet", 1, Item.TYPEPFOOD, 10, 1, 5f));

        for(int i = 0; i < required.Count; i++)
        {
            productImages[i+1].sprite = Resources.Load<Sprite>(required[i].imgUrl);
            productCount[i+1].text = "x" + required[i].count.ToString();
        }
    }

    private void completeOrder()
    {
        if (Player.isEnoughItems(required))
        {
            for (int i = 0; i < required.Count; i++)
            {
                Player.removeItemWithName(required[i].name, required[i].count);
            }
            Destroy(gameObject);
        }
    }
}
