using UnityEngine;
using UnityEngine.InputSystem;

public class Shieldfunction : MonoBehaviour
{
    public Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void OnShield(InputAction.CallbackContext context)
    //{
    //    if(context.phase == InputActionPhase.Started)
    //    {
    //        this .gameObject.SetActive(true);
    //        player.block = 0;
    //    }

    //    if (context.phase == InputActionPhase.Performed)
    //    {
    //        player.block = 1;
    //        this .gameObject.SetActive(false);
    //    }
    //}
}
