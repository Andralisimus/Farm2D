using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    private Text price;
    private Text moneyText;
    private Image productImage;

    private Text lvlText;
    private Image lvlImage;

    void Start()
    {
        price = GetComponentsInChildren<Text>()[0];
        productImage = GetComponentsInChildren<Image>()[1];

        lvlText = GetComponentsInChildren<Text>()[1];
        lvlImage = GetComponentsInChildren<Image>()[2];
    }

    private void Buy(Item item)
    {
        if (Player.money >= item.price)
        {
            Player.checkIfItemExists(item);
            Player.money -= item.price;
            moneyText.text = Player.money + "$";
            DataBase.Save();
        }
    }

    public void UpdateItem(Item item, Text moneyText)
    {
        if (item.lvlWhenUnlock > Player.lvl)
        {
            GetComponent<Button>().onClick.RemoveAllListeners();
            lvlText.enabled = true;
            lvlText.text = "Unlocks at lvl " + item.lvlWhenUnlock.ToString();
            productImage.sprite = Resources.Load<Sprite>(item.imgUrl);

            lvlImage.enabled = true;
        }
        else {
            this.moneyText = moneyText;
            lvlImage.enabled = false;
            lvlText.enabled = false;

            productImage.sprite = Resources.Load<Sprite>(item.imgUrl);
            price.text = item.price + "$";
            GetComponent<Button>().onClick.RemoveAllListeners();
            GetComponent<Button>().onClick.AddListener(delegate { Buy(item); });
        }
    }
}
