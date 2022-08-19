using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 10.0f;

    private int currentScene;
    private string sceneName;

    private BoxCollider2D boxCollider2d;

    private Rigidbody2D rBody;

    private void Awake() {
        rBody = GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    private void Start() {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        //change horiz axis by speed
        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        if (GroundCheck() && Input.GetKeyDown(KeyCode.Space))
        {
            rBody.velocity = Vector2.up * jumpForce;
        }
    }

    private bool GroundCheck(){
        float extraHeight = 0.05f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, boxCollider2d.bounds.extents.y + extraHeight, platformsLayerMask);

        //RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, boxCollider2d.bounds.extents.y + extraHeight, platformsLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(boxCollider2d.bounds.center, Vector2.down * (boxCollider2d.bounds.extents.y + extraHeight), rayColor);
        return raycastHit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == 7){
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
