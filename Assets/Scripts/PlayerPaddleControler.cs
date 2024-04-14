using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleControler : MonoBehaviour
{
    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;
    public string movementAxisName = "Vertical";

    public float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        if (isPlayer)
            spriteRenderer.color = SaveControler.Instance.colorPlayer;
        else
            spriteRenderer.color = SaveControler.Instance.colorEnemy;
    }
    void Update()
    {
        float moveInput = Input.GetAxis(movementAxisName);
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;
        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);
        transform.position = newPosition;

    }
}
