using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        Character char1 = new Character();
        Character char2 = new Character();

        //�����ؿ�
        BattleMgr.Instance().ChangeStep(BattleStep.Init);
        
    }

    void Update()
    {
        
    }


}
