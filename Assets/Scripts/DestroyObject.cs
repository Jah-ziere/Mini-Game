using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour

{
    public GameObject objectToDestroy; 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(objectToDestroy,10f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
