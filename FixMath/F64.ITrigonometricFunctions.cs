using System.Numerics;

namespace GamesWithGravitas.FixMath;

public partial struct F64 : ITrigonometricFunctions<F64>
{
    public static F64 Tau => Pi2;

    public static F64 AcosPi(F64 x) => Acos(x) / Pi;

    public static F64 AsinPi(F64 x) => Asin(x) / Pi;

    public static F64 AtanPi(F64 x) => Atan(x) / Pi;

    public static F64 CosPi(F64 x) => Cos(x * Pi);

    public static (F64 Sin, F64 Cos) SinCos(F64 x) => (Sin(x), Cos(x));

    public static (F64 SinPi, F64 CosPi) SinCosPi(F64 x) => (Sin(Pi*x), Cos(Pi*x));

    public static F64 SinPi(F64 x) => Sin(x * Pi);

    public static F64 TanPi(F64 x) => Tan(x * Pi);
}