using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplicationBase : MonoBehaviour
{
    public GameObject bullet;
    public float reloadTime;
    public AudioClip bulletSound;

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

        Vector3 leadAttackerPosition = listAttackersInRange[0].transform.position;

        float theta = Mathf.Atan2(leadAttackerPosition.y - transform.position.y, leadAttackerPosition.x - transform.position.x);
        transform.eulerAngles = new Vector3(0, 0, theta * Mathf.Rad2Deg);

        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<BulletAnimation>().angle = theta;
        newBullet.GetComponent<BulletAnimation>().bulletType = "multiplication";
        source.clip = bulletSound;
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
