using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite chestOpened;

    public GameObject starPrefab;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OpenChest()
    {
        spriteRenderer.sprite = chestOpened;
        InvokeRepeating("CreateStar", 0.0f, 0.5f);

    }

    public void CreateStar()
    {
        GameObject star = Instantiate(starPrefab, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);

        star.GetComponent<Rigidbody2D>().AddForce(Vector2.up);
    }
}
