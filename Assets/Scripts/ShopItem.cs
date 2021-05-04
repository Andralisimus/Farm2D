using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    private Text price;
    private Text moneyText;
    private Image productImage;

    void Start()
    {
        price = GetComponentsInChildren<Text>()[0];
        productImage = GetComponentsInChildren<Image>()[1];
    }

    private void Buy(Item item)
    {
        if (Player.money >= item.price)
        {
            Player.checkIfItemExists(item);
            Player.money -= item.price;
            moneyText.text = Player.money + "$";
        }
    }

    public void UpdateItem(Item item, Text moneyText)
    {
        this.moneyText = moneyText;

        productImage.sprite = Resources.Load<Sprite>(item.imgUrl);
        price.text = item.price + "$";
        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(delegate { Buy(item); });
    }
}
