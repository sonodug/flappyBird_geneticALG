using System;

public class ActivateFunctions
{
    public float Sigmoid(float x)
    {
        float k = (float)Math.Exp(x);
        return k / (1.0f + k);
    }

    public float Tanh(float x)
    {
        return (float)Math.Tanh(x);
    }

    public float Relu(float x)
    {
        return (0 >= x) ? 0 : x;
    }

    public float Leakyrelu(float x)
    {
        return (0 >= x) ? 0.01f * x : x;
    }

    public float SigmoidDer(float x)
    {
        return x * (1 - x);
    }

    public float TanhDer(float x)
    {
        return 1 - (x * x);
    }

    public float ReluDer(float x)
    {
        return (0 >= x) ? 0 : 1;
    }

    public float LeakyreluDer(float x)
    {
        return (0 >= x) ? 0.01f : 1;
    }
}
