using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool start = false;
    public AnimationCurve curve;
    public float duration = 1f;


    void Update()
    {
        if (start)
        {
            start = false;
            {
                StartCoroutine(Shaking());
            }
        }

        IEnumerator Shaking()
        {
            Vector3 startposition = transform.position;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float strength = curve.Evaluate(elapsedTime / duration);
                transform.position = startposition + Random.insideUnitSphere * strength;
                yield return null;
            }

            transform.position = startposition;
        }



    }
}
