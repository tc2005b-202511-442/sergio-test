using UnityEngine;

public class Cubito : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject miCubito = GameObject.CreatePrimitive(PrimitiveType.Cube);
        miCubito.transform.position = new Vector3(3, 10, 0);
        //3 a la derecha, 2 arriba, 7 atrás
        Rigidbody rb = miCubito.AddComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
