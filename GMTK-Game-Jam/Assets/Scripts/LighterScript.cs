using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LighterScript : MonoBehaviour
{
    private System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    private bool isIn = false;
    private GameObject obj;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Hands" && !isIn) {
            sw.Start();
            isIn = true;
            obj = col.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Hands" && isIn) {
            sw.Stop();
            isIn = false;
            obj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        }
    }

    void Update()
    {
        if (isIn && sw.Elapsed.Seconds > 5) {
            SceneManager.LoadScene("End2");
        }
    }

    void FixedUpdate()
    {
        if (isIn) {
            var renderer = obj.GetComponent<SpriteRenderer>();
            renderer.color = new Color(1, renderer.color.g - (.1f * Time.fixedDeltaTime), renderer.color.b - (.1f * Time.fixedDeltaTime));
        }
    }
}
