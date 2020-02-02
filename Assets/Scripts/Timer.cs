using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    [SerializeField]
    Text timetext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timetext.text = time.ToString();
    }

    public void ResetTimer()
    {
        time = 0f;
        timetext.text = time.ToString();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
