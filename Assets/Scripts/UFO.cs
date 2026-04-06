using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class UFO : MonoBehaviour
{
    int hitPoints = 12;
    int block = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageEnemy(int dmg)
    {
        hitPoints = hitPoints - dmg * block;
    }
}
