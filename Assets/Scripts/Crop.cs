using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    private int STEP_EMPTY = 0;
    private int STEP_GROWS = 1;
    private int STEP_READY = 2;
    private int STEP_PLOW = 3;

    private SpriteRenderer seedSpriteRenderer;
    private SpriteRenderer productSpriteRenderer;
    private SpriteRenderer cropSpriteRenderer;

    private Item cropItem;
    private int step = 0;

    private GameObject player;
    private bool readyForAction;

    void Start()
    {
        cropSpriteRenderer = GetComponent<SpriteRenderer>();
        seedSpriteRenderer = GetComponentsInChildren<SpriteRenderer>()[2];
        productSpriteRenderer = GetComponentsInChildren<SpriteRenderer>()[1];

        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        Item item = new Item("beet", "Food/beet", 1, Item.TYPEPFOOD, 10, 1, 5f);

        if (readyForAction)
        {
            if (step == STEP_EMPTY)
            {
                if (item.type == Item.TYPEPFOOD)
                {
                    step = STEP_GROWS;
                    cropItem = item;
                    seedSpriteRenderer.sprite = Resources.Load<Sprite>("Food/seeds");
                    StartCoroutine(grow());
                }
            }
            else if (step == STEP_READY)
            {
                productSpriteRenderer.sprite = Resources.Load<Sprite>("Food/empty");
                seedSpriteRenderer.sprite = Resources.Load<Sprite>("Food/extraDirt");
            }
        }
    }

    private IEnumerator grow()
    {
        yield return new WaitForSeconds(cropItem.timeToGrow);

        seedSpriteRenderer.sprite = Resources.Load<Sprite>("Food/empty");
        productSpriteRenderer.sprite = Resources.Load<Sprite>(cropItem.imgUrl);

        step = STEP_READY;
    }

    private void FixedUpdate()
    {
        if (step != STEP_GROWS)
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) < 0.2f)
            {
                readyForAction = true;
                cropSpriteRenderer.sprite = Resources.Load<Sprite>("Food/cropSelected");
            }
            else
            {
                readyForAction = false;
                cropSpriteRenderer.sprite = Resources.Load<Sprite>("Food/crop");
            }
        }
        else
        {
            cropSpriteRenderer.sprite = Resources.Load<Sprite>("Food/crop");
        } 
    }
}
