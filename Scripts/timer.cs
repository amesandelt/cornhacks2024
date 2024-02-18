using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{   public float time = 30.0f;

    [SerializeField] GameObject x;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            x.SetActive(true);
        }
    }
    void OnTimedEvent(object source)
    {
        Debug.Log("30s");
    }
}
