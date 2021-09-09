using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] Text dialogText;
    [SerializeField] int lettersperSecond;
    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetails;
    [SerializeField] Color highlightedColor;

    [SerializeField] List<Text> actionText;
    [SerializeField] List<Text> moveText;
    [SerializeField] Text mpCost;
    [SerializeField] Text mpLeft;

    public List<Text> ActionText
    {
        get { return actionText; }
    }
    public List<Text> MoveText
    {
        get { return moveText; }
    }


    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach( var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersperSecond);
        }

        yield return new WaitForSeconds(1f);
    }

    public void EnableDialogText(bool enabled)
    {
        dialogText.enabled = enabled;
    }

    public void EnableActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }
    public void EnableMoveSelector(bool enabled)
    {
        moveSelector.SetActive(enabled);
        moveDetails.SetActive(enabled);
    }

    public void UpdateActionSelection(int selectedAction)
    {
        for(int i=0; i<actionText.Count; i++)
        {
            if(i == selectedAction)
            {
                actionText[i].color = highlightedColor;
            } else
            {
                actionText[i].color = Color.white;
            }
        }
    }

    public void UpdateMoveSelection(int currentAction, Move currentMove, Monster monster)
    {
        for (int i = 0; i < moveText.Count; i++)
        {
            if (i == currentAction)
            {
                moveText[i].color = highlightedColor;
            }
            else
            {
                moveText[i].color = Color.white;
            }
        }
        mpCost.text = $"MP Cost: {currentMove.MP}";
        mpLeft.text = $"{monster.MP}/{monster.MaxMP}";
    }

    public void SetMoveNames(List<Move> moves)
    {
        for(int i=0; i<moveText.Count; i++)
        {
            if(i<moves.Count)
            {
                moveText[i].text = moves[i].Base.Name;
            } else
            {
                moveText[i].text = "";
            }
        }
    }

}