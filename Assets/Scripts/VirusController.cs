using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{
    private Rigidbody2D rbVirus;
    public float distanceX;
    private float maxX;
    private float minX;
    private bool detectingPos = false;
    private bool firstMove = false;
    public float speed;
    public CircleCollider2D phase1Collider;



    private void Awake() {
        rbVirus = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        VirusMovement();
    }

    public void VirusMovement() {
        if (!detectingPos) {
            maxX = rbVirus.position.x + distanceX;
            minX = rbVirus.position.x - distanceX;
            detectingPos = true;
        }

        if (!firstMove) {
            rbVirus.velocity = new Vector2(speed, 0f);
            firstMove = true;
        }

        if (rbVirus.position.x > maxX) {
            rbVirus.velocity = new Vector2(-speed, 0f);
            transform.localScale = new Vector3(0.15f, 0.15f, 0);
        } else if (rbVirus.position.x < minX) {
            rbVirus.velocity = new Vector2(speed, 0f);
            transform.localScale = new Vector3(-0.15f, 0.15f, 0);
        }

    }

    private void OnTriggerStay2D(Collider2D collision) {
        rbVirus.position = Vector2.Lerp(transform.position, collision.transform.position, 0.02f);
    }


}
