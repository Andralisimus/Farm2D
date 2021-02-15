using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject inventoryPrefab;

    private bool inventoryOpened;
    private GameObject inventory;

    public void openInventory()
    {
        if (inventoryOpened)
        {
            Destroy(inventory);
            inventoryOpened = false;
        } else
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
