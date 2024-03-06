using System.Numerics;

namespace GamesWithGravitas.FixMath;

public partial struct F32 : ITrigonometricFunctions<F32>
{
    public static F32 Tau => Pi2;

    public static F32 AcosPi(F32 x) => Acos(x) / Pi;

    public static F32 AsinPi(F32 x) => Asin(x) / Pi;

    public static F32 AtanPi(F32 x) => Atan(x) / Pi;

    public static F32 CosPi(F32 x) => Cos(x * Pi);

    public static (F32 Sin, F32 Cos) SinCos(F32 x) => (Sin(x), Cos(x));

    public static (F32 SinPi, F32 CosPi) SinCosPi(F32 x) => (Sin(Pi*x), Cos(Pi*x));

    public static F32 SinPi(F32 x) => Sin(x * Pi);

    public static F32 TanPi(F32 x) => Tan(x * Pi);
}
