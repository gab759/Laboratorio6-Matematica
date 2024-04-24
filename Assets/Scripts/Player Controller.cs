using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody myRBD;
    [SerializeField] private float velocityModifier = 5f;
    [SerializeField] private float rotationAngle = 35f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private int life = 3;
    [SerializeField] public TextMeshProUGUI textLife;
    private TextMeshProUGUI _compTextMesh;

    void Start()
    {
        _compTextMesh = GetComponent<TextMeshProUGUI>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 movementPlayer = context.ReadValue<Vector2>();
        myRBD.velocity = new Vector3(movementPlayer.x * velocityModifier, movementPlayer.y * velocityModifier, 0f);

        float rotationZ = Mathf.Atan2(movementPlayer.y, movementPlayer.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, rotationZ + rotationAngle);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            life = life - 1;
            if (textLife != null)
            {
                textLife.text = "Vida: " + life.ToString();
            }
        }
    }
    private void Update()
    {
        if (life <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Perdiste PEPEPE");
            Time.timeScale = 0f;
        }
    }
}

