using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wilk : Interactable
{

    //przeladowanie fukcji czy interakcja gracza zachodzi z daną klasą czy nadrzędną 

    //przeladowuje funkcje virtualna ovveride
    public override void Interact()
    {
        Debug.Log("Interact() with in Wilk"); //DZIALA !!!! 

    }

    private void FixedUpdate()
    {
        //funkcja wyszukujaca pozycje gracza przez Plater Agent w klasie nadrzędnej
            // z czytanie pozycji 
            // poruszenie sie Wilka do pozycji gracza.
    }
    
}
