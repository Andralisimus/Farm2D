using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
{
    private GameObject player;
    private GameObject inventory;
    private SpriteRenderer deskSpriteRenderer;
    private bool allowClick = false;


    // Start is called before the first frame update
    void Start()
    {
        deskSpriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        inventory = GameObject.FindWithTag("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (allowClick)
        {
            inventory.GetComponent<Menu>().openDesk();
        }
    }

        private void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < 0.2f)
        {
            allowClick = true;
            deskSpriteRenderer.sprite = Resources.Load<Sprite>("Tools/DeskSelected");
        } else
        {
            allowClick = false;
            deskSpriteRenderer.sprite = Resources.Load<Sprite>("Tools/Desk");
        }
    }
}
