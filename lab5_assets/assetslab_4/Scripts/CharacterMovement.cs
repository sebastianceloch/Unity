using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 10.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        // zak�adamy, �e komponent CharacterController jest ju� podpi�ty pod obiekt
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // wyci�gamy warto�ci, aby mo�liwe by�o ich efektywniejsze wykorzystanie w funkcji
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // dzi�ki parametrowi playerGrounded mo�emy doda� zachowania, kt�re b�d�
        // mog�y by� uruchomione dla ka�dego z dw�ch stan�w
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // zmieniamy spos�b poruszania si� postaci
        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // transform.right odpowiada za ruch wzd�u� osi x (pami�tajmy, �e warto�ci b�d� zar�wno dodatnie
        // jak i ujemne, a punkt (0,0) jest na �rodku ekranu) a transform.forward za ruch wzd�� osi z.
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // to ju� nam potrzebne nie b�dzie
        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            // wz�r na si�� 
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        // pr�dko�� swobodnego opadania zgodnie ze wzorem y = (1/2 * g) * t-kwadrat 
        // okazuje si�, �e jest to zbyt wolne opadanie, wi�c zastosowano g * t-kwadrat
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}