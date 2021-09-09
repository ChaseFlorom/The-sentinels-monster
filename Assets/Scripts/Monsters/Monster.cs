using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;

public class Monster
{
    public MonsterBase Base { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }
    public int MaxHP { get; set; }

    public int MP { get; set; }
    public int MaxMP { get; set; }

    public int Attack { get; set; }
    public int Defense { get; set; }

    public List<Move> Moves { get; set; }
    public Monster( MonsterBase mBase, int mLevel)
    {
        Base = mBase;
        Level = mLevel;
        HP = Base.MaxHP;
        MaxHP = Base.MaxHP;
        MP = Base.MaxMP;
        MaxMP = Base.MaxMP;
        Attack = Base.Attack;
        Defense = Base.Defense;

        Moves = new List<Move>();
        //Learn the move if the Monster is the required level.
        foreach(var move in Base.LearnableMoves)
        {
            if(Level >= move.Level)
            {
                Moves.Add(new Move(move.Base));
            }
            //Check if there are already four moves.
            if (Moves.Count >= 4)
                break;
        }


    }

    public DamageDetails TakeDamage(Move move, Monster attacker)
    {
        //Critical Hit Chance
        float criticalHit = 1f;
        if(Random.value * 100f <= 6.25)
        {
            criticalHit = 2f;
        }

        float type = TypeChart.GetEffectiveness(move.Base.MoveTag, this.Base.Tag1) * TypeChart.GetEffectiveness(move.Base.MoveTag, this.Base.Tag2);

        var damageDetails = new DamageDetails()
        {
            TagEffectiveness = type,
            Critical = criticalHit,
            Fainted = false
        };

        float modifiers = Random.Range(0.85f, 1f) * type * criticalHit;
        
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * move.Base.Power * ((float)attacker.Attack / Defense) + 2;
        int damage = Mathf.FloorToInt(d * modifiers);

        HP -= damage;
        if(HP <= 0 )
        {
            HP = 0;
            damageDetails.Fainted = true;
        } else
        {
            damageDetails.Fainted = false;
        }

        return damageDetails;
    }

    //Currently chooses a random move, will rework with better AI later.
    public Move AiChooseMove()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }
}


public class DamageDetails {
    public bool Fainted { get; set; }
    public float Critical { get; set; }
    public float TagEffectiveness { get; set; }
}