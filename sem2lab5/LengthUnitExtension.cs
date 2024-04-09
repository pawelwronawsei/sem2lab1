namespace sem2lab5;

public static class LengthUnitExtension
{
    public static double ToDouble(this LengthUnit unit)
    {
        return unit switch
        {
            LengthUnit.FT => 304.80,
            _ => (int)unit
        };
    }
    
    public static decimal ToDecimal(this LengthUnit unit)
    {
        return unit switch
        {
            LengthUnit.FT => (decimal)304.80,
            _ => (decimal)unit
        };
    }
}