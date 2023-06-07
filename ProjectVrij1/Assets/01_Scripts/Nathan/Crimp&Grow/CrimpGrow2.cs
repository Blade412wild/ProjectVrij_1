using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrimpGrow2 : MonoBehaviour
{
    public Vector3 MinScale;
    public bool Repeatable;
    public float Speed = 2.0f;
    public float duration = 5.0f;

    private Vector3 maxScale;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        maxScale = transform.localScale;

            yield return RepeatLerp(maxScale, MinScale, duration);

    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float _rate = (1.0f / time) * Speed;

        while(i < 1.0f)
        {
            i += Time.deltaTime * _rate;
            transform.localScale = Vector3.Lerp(a, b, i);

            yield return null;
        }
    }



}
