using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBounce : MonoBehaviour
{
    public float bounceSpeed = 8;
    public float bounceAmplitude = 0.05f;
    public float rotationSpeed = 90;

    private float startHeight;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        startHeight = transform.localPosition.y;
        time = Random.value * Mathf.PI * 2;
    }

    // Update is called once per frame
    void Update()
    {
        // animazione
        float finalheight = startHeight + Mathf.Sin(Time.time * bounceSpeed + time) * bounceAmplitude;
        var position = transform.localPosition;
        position.y = finalheight;
        transform.localPosition = position;

        // rotazione
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotation.y += rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        
    }
}
