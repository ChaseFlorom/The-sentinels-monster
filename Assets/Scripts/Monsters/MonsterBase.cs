using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Data;

[CreateAssetMenu(fileName = "Monster", menuName = "Monster/Create New Monster")]

public class MonsterBase : ScriptableObject
{
    [BoxGroup("Basic Information")]
    [SerializeField] int id;
    [BoxGroup("Basic Information")]
    [SerializeField] string name;

    [BoxGroup("Basic Information")]
    [TextArea]
    [SerializeField] string description;


    [HorizontalGroup("Meta Data", 75)]
    [VerticalGroup("Meta Data/sprites")]
    [PreviewField(75)]
    [SerializeField] Sprite leftSprite;

    [VerticalGroup("Meta Data/sprites")]
    [PreviewField(75)]
    [SerializeField] Sprite rightSprite;

    [VerticalGroup("Meta Data/tags")]
    [SerializeField] MonsterTags tag1;
    [VerticalGroup("Meta Data/tags")]
    [SerializeField] MonsterTags tag2;

    [VerticalGroup("Meta Data/tags")]
    [SerializeField] MonsterClass class1;
    [VerticalGroup("Meta Data/tags")]
    [SerializeField] MonsterClass class2;

    //Base Stats
    [BoxGroup("Statistics")]
    [SerializeField] int maxHP;
    [BoxGroup("Statistics")]
    [SerializeField] int attack;
    [BoxGroup("Statistics")]
    [SerializeField] int defense;
    [BoxGroup("Statistics")]
    [SerializeField] int maxMP;
    [BoxGroup("Statistics")]
    [SerializeField] int speed;
    [BoxGroup("Statistics")]
    [SerializeField] int spAttack;
    [BoxGroup("Statistics")]
    [SerializeField] int spDefense;
    [BoxGroup("Statistics")]
    [SerializeField] int luck;

    [BoxGroup("Learnable Moves")]
    [SerializeField] List<LearnableMove> learnableMoves;


    public int Id
    {
        get { return id; }
    }
    public string Name
    {
        get { return name; }
    }
    public string Description
    {
        get { return description; }
    }
    public Sprite LeftSprite
    {
        get { return leftSprite; }
    }
    public Sprite RightSprite
    {
        get { return rightSprite; }
    }
    public MonsterTags Tag1
    {
        get { return tag1; }
    }
    public MonsterTags Tag2
    {
        get { return tag2; }
    }
    public MonsterClass Class1
    {
        get { return class1; }
    }
    public MonsterClass Class2
    {
        get { return class2; }
    }
    public int MaxHP
    {
        get { return maxHP; }
    }
    public int Attack
    {
        get { return attack; }
    }
    public int Defense
    {
        get { return defense; }
    }
    public int Speed
    {
        get { return speed; }
    }
    public int Luck
    {
        get { return luck; }
    }
    public int MaxMP
    {
        get { return maxMP; }
    }
    public int SpAttack
    {
        get { return spAttack; }
    }
    public int SpDefense
    {
        get { return spDefense; }
    }
    public List<LearnableMove> LearnableMoves
    {
        get { return learnableMoves; }
    }
}


[System.Serializable]
public class LearnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base
    {
        get { return moveBase; }
    }
    public int Level
    {
        get { return level; }
    }
}




public enum MonsterTags
{
    None,
    Dark,
    Light,
    Sentinel,
    Fairy,
    water,
    fire
    

}

public enum MonsterClass
{
    None,
    Fighter,
    Mage,
    Support,
    Tank,
    Leader

}

public class TypeChart
{
    static float[][] tagChart = {
        //                      Non  dar lig sen fair wat fir
        /*None*/new float[]     {1f, 1f, 1f, 1f, 1f, 1f, 1f},
       /*Dark*/ new float[]     {1f, 1f, 2f, 1f, 2f, 1f, 1f},
        /*Light*/new float[]    {1f, 2f, 1f, 1f, .5f, 1f, 1f},
       /*Sentinel*/ new float[] {1f, 1f, 1f, 1f, 1f, 1f, 1f},
       /*Fairy*/ new float[]    {1f, .5f, .5f, 1f, .5f, 2f, 2f},
       /*Water*/ new float[]    {1f, 1f, 1f, 1f, 1f, .5f, 2f},
        /*Fire*/new float[]     {1f, 1f, 1f, 2f, 1f, .5f, .5f}
    };

    public static float GetEffectiveness(MonsterTags attackType, MonsterTags defenseType)
    {
        if (attackType == MonsterTags.None || defenseType == MonsterTags.None)
            return 1;

        int row = (int)attackType;
        int col = (int)defenseType;
        return tagChart[row][col];
    }
}
