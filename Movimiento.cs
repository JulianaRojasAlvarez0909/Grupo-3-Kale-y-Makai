using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 1f;
    public AudioClip clip;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            float axisX = Input.GetAxis("Horizontal");
            transform.position += new Vector3(velocidad * axisX, 0, 0) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
        StartCoroutine(Cinematica());
    }

    IEnumerator Cinematica()
    {
        canMove = false;
        yield return new WaitForSeconds(20);
        canMove = true;
    }
}
