using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    private Animator anim;
    private Rigidbody2D rbPlayer;
    public float speed;
    private float xPos;
    private float yPos;
    private bool moving;
    private int direction;
    private float lastMoveX;
    private float lastMoveY;

    [Header("Dialogue Canvas")]
    public GameObject[] dialogueText;
    public GameObject dialogueBox;
    public GameObject[] characterImage;


    private void Awake() {
        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        PlayerMovement();
    }

    public void PlayerMovement() {
        xPos = Input.GetAxisRaw("Horizontal");
        yPos = Input.GetAxisRaw("Vertical");

        anim.SetFloat("xPos", xPos);
        anim.SetFloat("yPos", yPos);

        if (xPos != 0 || yPos != 0) {
            if (!moving) {
                moving = true;
                anim.SetBool("Moving", moving);
                lastMoveX = xPos;
                lastMoveY = yPos;
                anim.SetFloat("LastMoveX", lastMoveX);
                anim.SetFloat("LastMoveY", lastMoveY);
            }

        } else {
            if (moving) {
                moving = false;
                anim.SetBool("Moving", moving);
            }

        }

        rbPlayer.velocity = new Vector2(xPos, 0f) * speed;
    }

    //DETECT COLLISIONS
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Dialogue")) {
            ShowDialogue(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Dialogue")) {
            DontShowDialogue(collision);
        }
    }

    public void ShowDialogue(Collider2D other) {
        dialogueBox.SetActive(true);
        string name = other.gameObject.name;

        switch (name) {
            case "Anciano":
                dialogueText[0].SetActive(true);
                characterImage[0].SetActive(true);
                break;
        }
    }

    public void DontShowDialogue(Collider2D other) {
        dialogueBox.SetActive(false);
        string name = other.gameObject.name;

        switch (name) {
            case "Anciano":
                dialogueText[0].SetActive(false);
                characterImage[0].SetActive(false);
                break;
        }
    }

}
