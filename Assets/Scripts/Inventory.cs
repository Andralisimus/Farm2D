using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{
    private List<Slot> slots = new List<Slot>();

    void Start()
    {
        slots = GetComponentsInChildren<Slot>().ToList();

        int i = 0;
        foreach (Slot slot in slots)
        {

            slot.fillSlot(Player.items[i]);
            i++;
        }
    }
}
