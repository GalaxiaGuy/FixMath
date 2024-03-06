using System.Numerics;

namespace GamesWithGravitas.FixMath;

public partial struct F32 : ISignedNumber<F32>
{
    public static F32 NegativeOne => Neg1;
}