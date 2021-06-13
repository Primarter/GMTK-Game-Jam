using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
    private Rigidbody2D m_Rigidbody2D;
    private Vector3 m_Velocity = Vector3.zero;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontalMove, float verticalMove, float torque)
    {
        Vector3 targetVelocity = new Vector2(horizontalMove * 10f, verticalMove * 10f);
        var impulse = (torque);
        if (torque != 0.0 && impulse != 0.0) {
            m_Rigidbody2D.AddTorque(impulse, ForceMode2D.Impulse);
        }
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }
}
