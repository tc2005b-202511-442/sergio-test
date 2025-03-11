using UnityEngine;
using UnityEngine.SceneManagement;

public class Pared : MonoBehaviour
{
    public int WIDTH;
    public int HEIGHT;
    void Suelo()
    {
        GameObject suelo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        suelo.transform.position = new Vector3(0,-0.3f, 0);
        suelo.transform.localScale = new Vector3(30.0f, 0.1f, 10.0f);
        Rigidbody rb = suelo.AddComponent<Rigidbody>();
        rb.mass = 1000.0f;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        
        PhysicsMaterial pm = new PhysicsMaterial();
        suelo.GetComponent<Collider>().material = pm;
        pm.bounciness = 0.0f;
        pm.dynamicFriction = 1.0f;
        pm.staticFriction = 1.0f;
        pm.frictionCombine = PhysicsMaterialCombine.Average;
        pm.bounceCombine = PhysicsMaterialCombine.Minimum;
        
    }

    void Tabique(Vector3 pos, int num)
    {
        GameObject tab = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tab.transform.localScale = new Vector3(0.98f, 0.5f, 0.5f);
        tab.transform.position = pos;
        tab.name = "Tabique_" + num;

        MeshRenderer mr = tab.GetComponent<MeshRenderer>();
        mr.material.color = new Color(0.97f, 0.46f, 0.0f);

        Rigidbody rb = tab.AddComponent<Rigidbody>();
        rb.mass = 5.0f;
    }

    void LaPared()
    {
        int contador = 1;
        float x = 0.0f;
        float y = 0.0f;
        float z = 0.0f;
        for (int r = 0; r < HEIGHT; r++)
        {
            for(int c = 0; c < WIDTH; c++)
            {
                x = c - WIDTH / 2.0f;
                if (r % 2 == 0) x += 0.5f;
                y = r/2.0f;
                z = 0.0f;
                Tabique(new Vector3(x, y, z), contador++);
            }
        }
    }

    void Start()
    {
        Suelo();
        LaPared();

        //GameObject bala = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //bala.transform.position = new Vector3(0, HEIGHT / 2.0f, -10.0f);
        //Rigidbody balaRB = bala.AddComponent<Rigidbody>();
        //balaRB.mass = 10.0f;
        //balaRB.AddForce(new Vector3(0,0,250.0f), ForceMode.Impulse);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene("Logic");
        }
    }
}
