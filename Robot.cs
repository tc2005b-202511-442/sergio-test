using Unity.Burst.Intrinsics;
using UnityEngine;

public class Robot : MonoBehaviour
{
    GameObject elRobot;
    public GameObject laBala; // PREFAB de la bala.
    int contador;
    void Start()
    {
        contador = 0;
        elRobot = new GameObject(); // Empty
        elRobot.name = "ROBOT";
        GameObject cuerpo = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        cuerpo.transform.parent = elRobot.transform; // Parent
        cuerpo.name = "CUERPO";
        //Camera.main.transform.parent = elRobot.transform;

        GameObject lArm = GameObject.CreatePrimitive(PrimitiveType.Cube);
        lArm.name = "L_ARM";
        lArm.transform.parent = elRobot.transform;
        lArm.transform.position = new Vector3(-0.5f - 0.1f, 0, 0.5f);
        lArm.transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);

        GameObject rArm = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rArm.name = "R_ARM";
        rArm.transform.parent = elRobot.transform;
        rArm.transform.position = new Vector3(0.5f + 0.1f, 0, 0.5f);
        rArm.transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);

        elRobot.transform.position = new Vector3(0, 1, -5.0f);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            // Mover el robot a la izquierda:
            Vector3 p = elRobot.transform.position;
            p.x -= 0.01f;
            elRobot.transform.position = p;
        }
        if(Input.GetKey(KeyCode.D))
        {
            // Mover el robot a la derecha:
            Vector3 p = elRobot.transform.position;
            p.x += 0.01f;
            elRobot.transform.position = p;
        }
        if(Input.GetKey(KeyCode.W))
        {
            // Mover el robot adelante:
            Vector3 p = elRobot.transform.position;
            p.z += 0.01f;
            elRobot.transform.position = p;
        }
        if(Input.GetKey(KeyCode.S))
        {
            // Mover el robot adelante:
            Vector3 p = elRobot.transform.position;
            p.z -= 0.01f;
            elRobot.transform.position = p;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bala = Instantiate(laBala); // Nueva instancia de la bala.
            contador++;
            if (contador % 2 == 0)
                bala.transform.position = elRobot.transform.position + new Vector3(-0.5f - 0.1f, 0, 1.5f);
            else
                bala.transform.position = elRobot.transform.position + new Vector3(0.5f + 0.1f, 0, 1.5f);
            bala.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 300f), ForceMode.Impulse);
            Destroy(bala, 3); // Destruir la instancia luego de 3s
        }
    }
}
