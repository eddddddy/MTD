using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restraints : MonoBehaviour
{
    public bool canCreate = false;
    private SpriteRenderer spriteRenderer;
    private List<Collider2D> listofViolations = new List<Collider2D>();

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("trackbounds"))
        {
            listofViolations.Add(other);
            canCreate = false;
            spriteRenderer.color = new Color(191/255.0f,96/255.0f,60/255.0f,133/255.0f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("trackbounds"))
        {
            listofViolations.Remove(other);
            if (listofViolations.Count == 0)
            {
                canCreate = true;
                spriteRenderer.color = new Color(60 / 255.0f, 191 / 255.0f, 132 / 255.0f, 160 / 255.0f);
            }
        }
    }
}
