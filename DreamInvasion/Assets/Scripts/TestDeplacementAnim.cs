using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class TestDeplacementAnim : MonoBehaviour {


    private Animator m_Anim;
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;
    float move;
    [SerializeField]
    float m_MaxSpeed = 2.0f;

    // Use this for initialization
    void Start () {

        m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        // Read the inputs.
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        move = CrossPlatformInputManager.GetAxis("Horizontal1");

    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.P)) {
            m_Anim.SetBool("rien", false);
            m_Anim.SetBool("droite", true);
            m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);


            if (move > 0 && !m_FacingRight) {
                // ... flip the player.
                Flip();
            }
                // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight) {
                // ... flip the player.
                Flip();
            }

        }

        if (Input.GetKeyDown(KeyCode.O)) {
            m_Anim.SetBool("rien", false);
            m_Anim.SetBool("gauche", true);
            transform.Translate(Vector3.left);
        }

        if (Input.GetKeyUp(KeyCode.P)) {
            m_Anim.SetBool("droite", false);
            m_Anim.SetBool("gauche", false);
            m_Anim.SetBool("rien", true);

        }

        if (Input.GetKeyUp(KeyCode.O)) {
            m_Anim.SetBool("droite", false);
            m_Anim.SetBool("gauche", false);
            m_Anim.SetBool("rien", true);

        }

    }

    private void Flip() {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
