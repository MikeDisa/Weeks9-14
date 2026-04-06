using UnityEngine;

public class Player : MonoBehaviour
{
    public int hitPoints = 3;
    int block = 1; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DamagePlayer(int dmg)
    {
        hitPoints = hitPoints - dmg * block;
        if (hitPoints == 0)
        {
            Debug.Log("hit");
        }
    }
}
