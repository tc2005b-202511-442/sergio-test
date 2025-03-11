using UnityEngine;

public class Ejercicio : MonoBehaviour
{
    void Suelo()
    {
        GameObject suelo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        suelo.transform.localScale = new Vector3(10.0f, 0.1f, 10.0f);
        Rigidbody rb = suelo.AddComponent<Rigidbody>();
        rb.mass = 1000.0f;
        rb.constraints = RigidbodyConstraints.FreezeAll;

        PhysicsMaterial pm = new PhysicsMaterial();
        suelo.GetComponent<Collider>().material = pm;
        pm.bounciness = 1.0f;
        pm.dynamicFriction = 0.0f;
        pm.staticFriction = 0.0f;
        pm.frictionCombine = PhysicsMaterialCombine.Minimum;
        pm.bounceCombine = PhysicsMaterialCombine.Maximum;
    }

    void Esferita()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float y = Random.Range(8.0f, 12.0f);
        float z = Random.Range(-5.0f, 5.0f);
        GameObject sph = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sph.transform.position = new Vector3(x, y, z);

        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        MeshRenderer mr = sph.GetComponent<MeshRenderer>();
        mr.material.color = new Color(r, g, b);

        Rigidbody rb = sph.AddComponent<Rigidbody>();
        rb.mass = 1.0f;
    }

    void Start()
    {
        Suelo();

        Esferita();
        Esferita();
        Esferita();
    }

    void Update()
    {
        
    }
}
