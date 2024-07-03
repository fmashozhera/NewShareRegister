namespace ShareRegister.Domain.Extenstions;
public static class EnumExtensions
{
    public static TEnum GetEnumValue<TEnum>(this string value) where TEnum : struct
    {
        if (!typeof(TEnum).IsEnum)
        {
            throw new ArgumentException("TEnum must be an enumeration type.");
        }

        if (Enum.TryParse(value, out TEnum result))
        {
            return result;
        }
        else
        {
            throw new ArgumentException($"'{value}' is not a valid value for enum {typeof(TEnum).Name}");
        }
    }
}
