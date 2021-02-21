using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Image slotImage;
    private Image itemImage;
    private Text countText;

    private int id;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate { Click(); });
    }

    public void fillSlot(int id)
    {
        this.id = id;
        Item item = Player.items[id];

        slotImage = GetComponent<Image>();
        itemImage = GetComponentsInChildren<Image>()[1];
        countText = GetComponentInChildren<Text>();

        if (item.count > 0) countText.text = "x" + item.count.ToString();
        else countText.text = "";
        itemImage.sprite = Resources.Load<Sprite>(item.imgUrl);
    }

    public void Click()
    {
        if(Inventory.selectedSlot == null)
        {
            slotImage.sprite = Resources.Load<Sprite>("Canvas/placeHolderSelected");
            Inventory.selectedSlot = this;
        }
        else if(Inventory.selectedSlot == this)
        {
            slotImage.sprite = Resources.Load<Sprite>("Canvas/placeHolder");
            Inventory.selectedSlot = null;
        }
        else
        {
            Inventory.selectedSlot.slotImage.sprite = Resources.Load<Sprite>("Canvas/placeHolder");

            Item item = Player.items[Inventory.selectedSlot.id];
            Player.items[Inventory.selectedSlot.id] = Player.items[id];
            Player.items[id] = item;

            Inventory.selectedSlot.fillSlot(Inventory.selectedSlot.id);
            fillSlot(id);

            Inventory.selectedSlot = null;
        }
    }
}
