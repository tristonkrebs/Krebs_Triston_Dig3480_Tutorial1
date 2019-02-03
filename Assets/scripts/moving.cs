using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour

{
    private bool state;
    public float speed;
    private float pos;
    public float start;
    public float end;
    public float Z;

    // Start is called before the first frame update
    void Start()
    {
        state = true;
        pos = start;
    }

    // Update is called once per frame
    void Update()
    {
        if (state)
            pos = pos + speed;

        else
            pos = pos - speed;

        transform.localPosition = new Vector3(pos, .5f, Z);
       if (pos > end)
            state = false;
        else if (pos < start)
            state = true;
    }
}
