using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScopeVisibility : MonoBehaviour
{
    public static ScopeVisibility instance;
    public  bool isDrag = false;
    private SpriteRenderer spriteRenderer;
    public GameObject bullet;
    public GameObject spawner;
    public  bool isBulletSpawn = false;
    public float speed = 10;
    private int bulletCounter = 4;
    public GameObject[] bulets;

    void Start()
    {
      instance = this;
      spriteRenderer = GetComponent<SpriteRenderer>(); 
    }
    void Update()
    {
        bulets[bulletCounter].SetActive(false);
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        transform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, transform.position.z);
        if (isDrag)
        {
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }
    }
    void SpawnBullet()
    {
         Instantiate(bullet,spawner.transform.position , Quaternion.Euler(0, 0, spawner.transform.eulerAngles.z)); 
    }

    private void OnMouseDown()
    {
        isDrag = true;
    }
    private void OnMouseUp()
    {
        isBulletSpawn = true;
        if (bulletCounter > 0)
        {
            SpawnBullet();
            bulletCounter--;
        }
        
        isDrag = false;
    }
}

