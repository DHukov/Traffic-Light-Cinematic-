using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class For : MonoBehaviour
{
    private bool done = true;

    void Update()
    {
        while(done)
            ForMethode();
    }
    public void ForMethode()
    {
        for(int i = 1; i <= 1000; i++)
        {                
            if (i % 3 == 0)
                Debug.Log("Ba " + i);
            if (i % 5 == 0)
                Debug.Log("za " + i);
            if (i % 15 == 0)
                Debug.Log("Baza " + i);

            if (i % 3 != 0 && i % 5 != 0 && i % 15 != 0)
                Debug.Log(i);
                if (i >= 1000)
                done = false;

        }
    }
}
