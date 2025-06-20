using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class AimStripeRotate : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �������� ������� ���� � ������� �����������
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        // ���������� ��������� z, ��� ��� �������� � 2D
        Vector2 direction = new Vector2(
            mouseWorldPosition.x - transform.position.x,
            mouseWorldPosition.y - transform.position.y
        );

        // ��������� ���� � ��������
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ������������ ������ ���, ����� �� ������� �� ������
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (ScopeVisibility.instance.isDrag && spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }
    }
}
