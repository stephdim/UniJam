using System;
using UnityEngine;
using UnityStandardAssets._2D;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof (PlatformerCharacter2D))]
public class MyPlatformer2DUserControl : MonoBehaviour
{
    private PlatformerCharacter2D m_Character;
    private bool m_Jump;
    public float Speed { get; private set; }
    Character player;

    private void Awake()
    {
        m_Character = GetComponent<PlatformerCharacter2D>();
        player = GetComponent<Character>();
    }


    private void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump"+player.id);
        }
    }


    private void FixedUpdate()
    {
        // Read the inputs.
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        float h = CrossPlatformInputManager.GetAxis("Horizontal"+player.id);
        // Pass all parameters to the character control script.
        m_Character.Move(h, crouch, m_Jump);
        Speed = h;
        m_Jump = false;
    }
}
