using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleScript : MonoBehaviour
{
    private int m_hitCount = 0;
    [SerializeField]
    private Sprite m_replacement;
    [SerializeField]
    private int m_maxHits = 5;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Hands")
            m_hitCount += 1;
        if (m_hitCount >= m_maxHits) {
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = m_replacement;
            this.enabled = false;
        }
    }
}
