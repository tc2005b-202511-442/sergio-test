using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;

public class Controlador : MonoBehaviour
{
    // TMP = TextMeshPro
    public TMP_InputField grupo_TMPIF;
    public TMP_InputField lista_TMPIF;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator TryLogin() // <<<----- using System.Collections
    {
        WWWForm form = new WWWForm();

        UserData ud = new UserData();
        ud.lista = int.Parse(lista_TMPIF.text);
        ud.grupo = int.Parse(grupo_TMPIF.text);

        form.AddField("datos", JsonUtility.ToJson(ud));
        using (UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8001/login", form))
        {
            yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else // Ya tenemos respuesta del server...
            {
                string txt = www.downloadHandler.text;
                Debug.Log(txt); // ¡Éxito!
            }
        }
    }

    public void VamosAJugar() // Comportamiento del botón "JUGAR"
    {
        string grupo = grupo_TMPIF.text;
        string lista = lista_TMPIF.text;
        // ToDo: Revisar DB para comprobar datos
        if (grupo.Length > 0 && grupo.All(char.IsNumber))
        {
            if(lista.Length > 0 && lista.All(char.IsNumber))
            {
                SceneManager.LoadScene("Logic");
                StartCoroutine(TryLogin());
            }
            else
            {
                Debug.Log("LOGIC No funciona por longitud o tipo de dato");
            }
        }
        else
        {
            Debug.Log("GRUPO No funciona por longitud o tipo de dato");
        }
    }
}
