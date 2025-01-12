using UnityEngine;

public class InputsToAction
{
    IInput[] inputs =
    {
        new KeyInput(),
    };

    public void Update()
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            inputs[i].Update();
        }
    }

    public Vector2 GetValue()
    {
        Vector2 res = Vector2.zero;
        for (int i = 0; i < inputs.Length; i++)
        {
            Vector2 temp = inputs[i].GetValue();
            if (temp.magnitude > res.magnitude)
            {
                res = temp;
            }
        }
        return res;
    }
}
