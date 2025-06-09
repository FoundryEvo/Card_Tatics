using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff
{
    //buffÃû³Æ
    public string BuffName { get; private set; }
    //buffÃèÊö
    public string Description { get; private set; }
    //buffĞ§¹û


}

public class Debuff : Buff
{

}