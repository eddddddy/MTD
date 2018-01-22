using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionUpgrade1 : MonoBehaviour
{
    public GameObject radial;
    public float reloadTime;
    public AudioClip pulseSound;

    private List<GameObject> listAttackersInRange = new List<GameObject>();
    private AudioSource source;
    bool waiting = false;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("attacker"))
        {
            if (!listAttackersInRange.Contains(other.gameObject))
            {
                listAttackersInRange.Add(other.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("attacker"))
        {
            if (listAttackersInRange.Contains(other.gameObject))
            {
                listAttackersInRange.Remove(other.gameObject);
            }
        }
    }

    IEnumerator Mutate()
    {
        waiting = true;

        GameObject newRadial = Instantiate(radial, transform.position, Quaternion.identity);
        newRadial.GetComponent<RadialAnimation>().maxRadius = GetComponent<CircleCollider2D>().radius;
        newRadial.GetComponent<RadialAnimation>().hoopType = "division";
        source.clip = pulseSound;
        source.time = 0.3f;
        source.Play();

        yield return new WaitForSeconds(reloadTime);
        waiting = false;
    }

    void Update()
    {
        if (listAttackersInRange.Count > 0 && !waiting)
        {
            StartCoroutine(Mutate());
        }
    }
}
