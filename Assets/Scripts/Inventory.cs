using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Inventory : MonoBehaviour
{
    private List<Slot> slots = new List<Slot>();
    public static Slot selectedSlot = null;

    private Text lvlText;
    private Text moneyText;
    private RectTransform barRectTransform;

    void Start()
    {
        lvlText = GetComponentsInChildren<Text>()[0];
        moneyText = GetComponentsInChildren<Text>()[1];

        barRectTransform = GetComponentsInChildren<Image>()[3].GetComponent<RectTransform>();

        barRectTransform.localScale = new Vector3(Player.lvlProgress, 1, 1);
        lvlText.text = "Lvl " + Player.lvl;
        moneyText.text = Player.money + "$";

        slots = GetComponentsInChildren<Slot>().ToList();

        int i = 0;
        foreach (Slot slot in slots)
        {
            slot.fillSlot(i);
            i++;
        }
    }
}
