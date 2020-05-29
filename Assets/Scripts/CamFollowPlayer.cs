using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    [SerializeField]private GameObject _player;

    public float smoothing=3f;
    // Start is called before the first frame update
    void Start()
    {
       // _player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
       MoveCamToPlayer();
    }

    private void MoveCamToPlayer()
    {
        Vector3 pos = new Vector3(_player.transform.position.x, _player.transform.position.y, this.transform.position.z);
        this.transform.position = Vector3.Lerp(transform.position,pos,smoothing*Time.deltaTime);
    }
}
