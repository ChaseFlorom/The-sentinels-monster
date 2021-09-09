using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;



[CreateAssetMenu(fileName = "Move", menuName = "Monster/Create New Move")]
public class MoveBase : ScriptableObject
{
    [BoxGroup("Basic Information")]
    [SerializeField] string name;

    [BoxGroup("Basic Information")]
    [TextArea]
    [SerializeField] string description;

    [BoxGroup("Stats")]
    [SerializeField] MonsterClass monsterClass;
    [SerializeField] MonsterTags moveTag;
    [BoxGroup("Stats")]
    [SerializeField] int power;
    [BoxGroup("Stats")]
    [SerializeField] int accuracy;
    [BoxGroup("Stats")]
    [SerializeField] int mp;


    //Expose Properties
    public string Name
    {
        get { return name; }
    }
    public string Description
    {
        get { return description; }
    }
    public MonsterClass MonsterClass
    {
        get { return monsterClass; }
    }
    public MonsterTags MoveTag
    {
        get { return moveTag; }
    }
    public int Power
    {
        get { return power; }
    }
    public int Accuracy
    {
        get { return accuracy; }
    }
    public int Mp
    {
        get { return mp; }
    }
}
