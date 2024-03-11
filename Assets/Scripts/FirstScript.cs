using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{
    private int numeroEntero = 10;
    private long numeroEnteroGrande = -58;
    public float numeroDecimal = -10.75555f;
    public double numeroDecimalGrande = 54.888887f;
    public string cadenaDeTexto = "Hola soy un string";
    public char letraSuelta = 'a';
    public bool boleana = false;

    // Start is called before the first frame update
    void Start()
    {
        //Asignamos un valor de 5 a nuestra variable numeroEntero
        numeroEntero = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
