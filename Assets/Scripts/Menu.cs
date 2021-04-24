using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject inventoryPrefab;
    public GameObject deskPrefab;

    private bool inventoryOpened;
    private bool deskOpened;
    private GameObject inventory;
    private GameObject desk;

    public void openInventory()
    {
        if (deskOpened) {
            Destroy(desk);
            deskOpened = false;
        } else
        {
            if (inventoryOpened)
            {
                Destroy(inventory);
                inventoryOpened = false;
            }
            else
            {
                inventory = Instantiate(inventoryPrefab);
                inventory.transform.SetParent(gameObject.transform);
                inventory.GetComponent<RectTransform>().offsetMin = new Vector2(100, 59);
                inventory.GetComponent<RectTransform>().offsetMax = new Vector2(-100, -50);
                inventory.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                inventoryOpened = true;
            }
        }
    }

    public void openDesk()
    {
        desk = Instantiate(deskPrefab);
        desk.transform.SetParent(gameObject.transform);
        desk.GetComponent<RectTransform>().offsetMin = new Vector2(100, 59);
        desk.GetComponent<RectTransform>().offsetMax = new Vector2(-100, -50);
        desk.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        deskOpened = true;
    }
}
