using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Image slotImage;
    private Image itemImage;
    private Text countText;

    void Start()
    {
        
    }

    public void fillSlot(Item item)
    {
        slotImage = GetComponent<Image>();
        itemImage = GetComponentsInChildren<Image>()[1];
        countText = GetComponentInChildren<Text>();

        if (item.count > 0) countText.text = "x" + item.count.ToString();
        else countText.text = "";
        itemImage.sprite = Resources.Load<Sprite>(item.imgUrl);
    }
}
