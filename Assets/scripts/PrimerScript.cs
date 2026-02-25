using UnityEngine;

public class PrimerScript : MonoBehaviour
{
    private int numeroEntero = 5;
    private float numeroDecimal = 7.5f;
    private double decimallargo;
    private bool verdaderoFalso = false;
    private string cadenaTexto = "Hola";
    private char letra = 'a';

    private int[] inArray = new int[5]{2, 9, 5, 4, 3};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inArray[2] = 27;

        numeroEntero = 37;

        cadenaTexto = "Hola Mundo";

        Debug.Log(cadenaTexto + "aasfdafd");
        Debug.Log(numeroEntero);

        Calculo();
    }

    public void Calculo()
    {
        numeroEntero = 7 + 5;
        numeroEntero = 2 - 7;
        numeroEntero = 4 / 3;


        numeroEntero = numeroEntero + 2;
        numeroEntero += 2;
        numeroEntero -= 2;

        numeroEntero++;

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
 // numeroEntero = 37;

       // //  cadenaTexto = "Hola Mundo";

      //   Debug.Log(cadenaTexto + "aasfdafd");
      //   Debug.Log(numeroEntero);
   // }