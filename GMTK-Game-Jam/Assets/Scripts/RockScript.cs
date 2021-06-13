using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RockScript : MonoBehaviour
{
    private int m_hitCount = 0;
    [SerializeField]
    private int m_maxHits = 5;

    [Header("Shake Screen Settings")]
    [SerializeField]
    private Camera m_camera;
    public float shakeStrength = 0.7f;
    public float decreaseFactor = 1.0f;

    private float shake = 0;
    private Vector3 startPos;

    void FixedUpdate()
    {
        if (shake > 0) {
            Vector2 vec = Random.insideUnitCircle * shakeStrength;
            m_camera.transform.localPosition = new Vector3(vec.x, vec.y, -10);
            shake -= Time.fixedDeltaTime * decreaseFactor;
        } else {
            m_camera.transform.localPosition = startPos;
            shake = 0;
        }
    }

    void Start()
    {
        startPos = m_camera.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Hands") {
            m_hitCount += 1;
            shake = .1f;
            startPos = m_camera.transform.localPosition;
        }
        if (m_hitCount >= m_maxHits) {
            SceneManager.LoadScene("End1");
        }
    }
}
