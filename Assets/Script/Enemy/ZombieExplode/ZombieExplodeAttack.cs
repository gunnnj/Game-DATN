using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieExplodeAttack : EnemyAttack
{
    public GameObject explode;
    private bool isExplode;
    protected override void OnAttack(GameObject target)
    {
        base.OnAttack(target);
        
        Invoke(nameof(DestroyEnemy),.5f);
    }

    public async void DestroyEnemy(){
        if(isExplode) return;
        Instantiate(explode,transform.position,Quaternion.identity);
        AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Explode);
        isExplode = true;
        transform.parent.gameObject.SetActive(false);
        transform.parent.position = Vector3.zero;
        await Task.Delay(1000);
        isExplode = false;
    }

}