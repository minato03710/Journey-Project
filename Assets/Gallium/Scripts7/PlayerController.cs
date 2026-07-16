using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    public GameObject bodyPrefab;

    public int maxBody = 10;
    List<Transform> bodyParts =new List<Transform>();

    List<Vector3> positions =
    new List<Vector3>();
    public GameObject bulletPrefab;

    public Transform firePoint;


    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            movement.y += 1;

        if (Keyboard.current.sKey.isPressed)
            movement.y -= 1;

        if (Keyboard.current.aKey.isPressed)
            movement.x -= 1;

        if (Keyboard.current.dKey.isPressed)
            movement.x += 1;

        movement = movement.normalized;
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            Shoot(Vector2.up);
        }

        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            Shoot(Vector2.down);
        }

        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            Shoot(Vector2.left);
        }

        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            Shoot(Vector2.right);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;

        positions.Insert(0, transform.position);

        if (positions.Count > 500)
        {
            positions.RemoveAt(positions.Count - 1);
        }

        for (int i = 0; i < bodyParts.Count; i++)
        {
            int index = Mathf.Min(
                (i + 1) * 8,
                positions.Count - 1);

            bodyParts[i].position =
                positions[index];
        }
    }
    public void Grow()
    {
        if (bodyParts.Count >= maxBody)
            return;

        GameObject body = Instantiate(bodyPrefab);

        if (bodyParts.Count == 0)
        {
            body.transform.position = transform.position;
        }
        else
        {
            body.transform.position =
                bodyParts[bodyParts.Count - 1].position;
        }

        bodyParts.Add(body.transform);
    }
    public bool RemoveBodyPart()
    {
        if (bodyParts.Count <= 0)
            return false;

        Destroy(bodyParts[bodyParts.Count - 1].gameObject);

        bodyParts.RemoveAt(bodyParts.Count - 1);

        return true;
    }
    public int GetBodyCount()
    {
        return bodyParts.Count;
    }
    void Shoot(Vector2 dir)
    {
        if (bodyParts.Count <= 0)
            return;

        Destroy(
            bodyParts[
            bodyParts.Count - 1].gameObject);

        bodyParts.RemoveAt(
            bodyParts.Count - 1);

        GameObject bullet =
        Instantiate(
            bulletPrefab,
            transform.position,
            Quaternion.identity);

        bullet.GetComponent<Bullet>()
              .SetDirection(dir);
    }
    
}
