using System.Numerics;

namespace GamesWithGravitas.FixMath;

public partial struct F64 : ISignedNumber<F64>
{
    public static F64 NegativeOne => Neg1;
}