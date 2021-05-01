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
    private RectTransform barRectTransform;

    void Start()
    {
        lvlText = GetComponentInChildren<Text>();
        barRectTransform = GetComponentsInChildren<Image>()[3].GetComponent<RectTransform>();

        barRectTransform.localScale = new Vector3(Player.lvlProgress, 1, 1);
        lvlText.text = "Lvl " + Player.lvl;

        slots = GetComponentsInChildren<Slot>().ToList();

        int i = 0;
        foreach (Slot slot in slots)
        {
            slot.fillSlot(i);
            i++;
        }
    }
}
