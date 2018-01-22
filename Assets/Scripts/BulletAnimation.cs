using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAnimation : MonoBehaviour
{

    public float angle;
    public string bulletType;

    private int k = 0;
    private Vector3 deltaDisplacement;
    private List<GameObject> hitAttackers = new List<GameObject>();

    void Start()
    {
        deltaDisplacement = 0.2f * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("attacker"))
        {
            hitAttackers.Add(other.gameObject);
        }
    }

    void Update()
    {
        if (k == 20)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = transform.position + deltaDisplacement;
            k++;

            if (hitAttackers.Count > 0)
            {
                Destroy(gameObject);

                GameObject hitAttacker = hitAttackers[Random.Range(0, hitAttackers.Count)];
                hitAttacker.GetComponent<Mutations>().bulletList.Add(bulletType);
            }
        }
    }
}
