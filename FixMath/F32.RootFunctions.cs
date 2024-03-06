using System.Numerics;

namespace GamesWithGravitas.FixMath;

public partial struct F32 : IRootFunctions<F32>
{
    public static F32 Cbrt(F32 x) => RootN(x, 3);

    public static F32 Hypot(F32 x, F32 y) => Sqrt(x * x + y * y);

    public static F32 RootN(F32 x, int n) => Pow(x, F32.One / F32.FromInt(n));
}
