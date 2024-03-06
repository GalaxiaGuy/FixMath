namespace GamesWithGravitas.FixMath;

public interface IFx<TSelf> where TSelf : IFx<TSelf>
{
    static abstract TSelf FromInt(int v);
    static abstract TSelf FromDouble(double v);
    static abstract bool IsInteger(TSelf value);
    static abstract bool IsEvenInteger(TSelf value);
    static abstract bool IsOddInteger(TSelf value);
    static abstract bool IsPow2(TSelf value);
    static abstract TSelf Cbrt(TSelf x);
    static abstract TSelf Hypot(TSelf x, TSelf y);
    static abstract TSelf RootN(TSelf x, int n);
    static abstract TSelf MinValue { get; }
    static abstract TSelf MaxValue { get; }
    double Double { get; }
}

public partial struct F32 : IFx<F32> { }
public partial struct F64 : IFx<F64> { }