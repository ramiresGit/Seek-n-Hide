using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHeroScript : MonoBehaviour
{
    #region Приватные поля

    /// <summary>
    /// Поле компонента контроллера
    /// </summary>
    private CharacterController controller;

    /// <summary>
    /// Скорость игрока
    /// </summary>
    private Vector3 playerVelocity;

    /// <summary>
    /// Признак того, что игрок прижат к земле
    /// </summary>
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f; 

    #endregion

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Выполнить прыжок
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
