using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatformSticky : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            other.collider.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            other.collider.transform.SetParent(null);
        }
    }
}
