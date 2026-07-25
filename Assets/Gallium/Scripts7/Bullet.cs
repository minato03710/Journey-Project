using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    void Update()
    {
        transform.Translate(
            direction *
            speed *
            Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Enemy") && (other.gameObject.TryGetComponent(out AntAI antAIScript))) //checks if collided object has enemy tag and also checks if it might have an AntAI script
        {
            GetComponent<Collider2D>().enabled = false; //This is meant to fix the double damage that is dealt but it doesnt work but might help stop triple dmg
            float healthValue = antAIScript.health; //if it has ant AI script it will give the healt value a float
            if (healthValue > 1) //if the health value is great than 1 it will minus 1 health
                {
                antAIScript.health -= 1;
                    Debug.Log("-1 Dmg to Enemy");
                    Destroy(gameObject);
                }
            //IMPORTANT: there is a bug here where a bullet does twice the damage for some reason, idk how to fix and with short time, just make stronger enemies double intended health
            
                
            else //if the enemy has minus or equal or no AntAi script it will destroy enemy
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                Debug.Log("Enemy Killed");
            }
                
        }
        else if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("Enemy Killed");
        }

        if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
