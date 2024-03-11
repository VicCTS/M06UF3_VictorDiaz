using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    //Las variables privadas no se muestran en el inspector a menos que tengan un SerializeField
    [SerializeField]private string name;
    public float height;
    public int age;
    public string greeting;

    public float firstNumber = 2;
    public float secondNumber = 5;
    public float result;

    public string firstString = "Texto 1";
    public string secondString = "Texto 2";
    public string resultString;

    // Start is called before the first frame update
    void Start()
    {
        SayHello();
        Add();
        Subtract();
        Multiply();
        Divide();
        Increase();
        Decrease();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SayHello()
    {
        Debug.Log(greeting);
    }

    public void Walk()
    {
        
    }

    public void Jump()
    {

    }
    
    public void Add()
    {
        result = firstNumber + secondNumber;
        Debug.Log(result);

        resultString = firstString + " " + secondString;
        Debug.Log(resultString);

        if(result == 5)
        {
            Debug.Log("el resultado de la suma es 5");
        }
        else if(result > 7)
        {
            Debug.Log("el resultado de la suma es mayor que 5");
        }
        else if(result < 5)
        {
            Debug.Log("resultado es menor que 5");
        }
        else
        {
            Debug.Log("el resultado no es ni 5 ni menor que 5 ni mayor que 7");
        }
        
        switch(result)
        {
            case 5:
                Debug.Log("el resultado es 5");
            break;
            case >7:
                Debug.Log("el resultado es mayor que 7");
            break;
            case <5:
                Debug.Log("el resultado es menor que 5");
            break;
            default:
                Debug.Log("el resultado no es ni 5 ni mayor que 7 ni menor que 5");
            break;
        }

        if(result > 7 && result < 10)
        {
            Debug.Log("el resultado es mayor que 7 y menor que 10");
        }
        else if(result < 1 || result == 3)
        {
            Debug.Log("el resultado es 3 o menor que 1");
        }
    }

    public void Subtract()
    {
        result = firstNumber - secondNumber;
        Debug.Log(result);
    }

    public void Multiply()
    {
        result = firstNumber * secondNumber;
        Debug.Log(result);
    }

    public void Divide()
    {
        result = firstNumber / secondNumber;
        Debug.Log(result);
    }

    public void Increase()
    {
        firstNumber++;
        Debug.Log(firstNumber);
    }

    public void Decrease()
    {
        firstNumber--;
        Debug.Log(firstNumber);
    }
}
