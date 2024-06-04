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

    private int[] arrayInt = new int[6];
    private string[] arrayString = {"hola", "adios", "buenos dias"};

    private int[,] arrayInt2 = new int[8,3]; 
    private int[,] arrayInt3 = {{5,8,9}, {23, 6, 9}, {67, 9, 0}};

    private List<int> listInt = new List<int>(8);
    private List<int> listInt2 = new List<int>() {6, 7, 90, 12, 16};

    private List<(int, string)> listaMixta;
    private List<(int, string)> listaMixta2 = new List<(int, string)>(5);
    private List<(int,string)> listaMixta3 = new List<(int, string)>() {(5, "hola"), (78, "adios")};

    // Start is called before the first frame update
    void Start()
    {
        //Asignamos un valor de 5 a nuestra variable numeroEntero
        numeroEntero = 5;

        //Debug.Log(arrayInt[2]);
        //Debug.Log(arrayInt3[1, 1]);

        arrayInt[0] = 15;
        arrayInt[1] = 7;

        arrayInt3[1, 1] = 20;

        /*
        listInt2.Add(18);
        listInt2.Remove(90);

        listInt2.RemoveAt(2);
        listInt2.Insert(3, 40);

        listInt2.Clear();
        */

        /*for(int i = 0; i < 5; i++)
        {
            Debug.Log(i);
        }*/

        /*int i = 0;
        while(i < 5)
        {
            Debug.Log(i);
            i++;
        }*/

        /*int i = 6;
        do
        {
            Debug.Log(i);
            i++;
        } while (i < 5);*/

        foreach (int item in listInt2)
        {
            Debug.Log(item);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
