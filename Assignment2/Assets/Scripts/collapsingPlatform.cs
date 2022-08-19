using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class collapsingPlatform : MonoBehaviour
{
    [SerializeField] public PlayableDirector playableDirector;
    // Start is called before the first frame updat
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            Play();
        }
    }
    public void Play(){
        playableDirector.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
