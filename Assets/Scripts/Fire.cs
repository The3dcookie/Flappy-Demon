using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed = 1;
    private bool moveUp = true;
    public float TransitionDelay = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (moveUp == true)
        {
            transform.Translate(new Vector2(0, 0.45f) * speed * Time.deltaTime);
        }
        else if (moveUp == false)
        {
            transform.Translate(new Vector2(0, -0.45f) * speed * Time.deltaTime);
        }
        StartCoroutine(Transition());


    }

    private void start()
    {

    }
    IEnumerator Transition()
    {
        moveUp = false;
        yield return new WaitForSeconds(TransitionDelay);
        moveUp = true;
        yield return new WaitForSeconds(TransitionDelay);
    }
}