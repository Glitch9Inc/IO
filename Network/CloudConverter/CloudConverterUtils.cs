using System;

namespace Glitch9.IO.Network
{
    public class CloudConverterUtils
    {
        public static string SafeConvertToString(object @object)
        {
            string result = @object.ToString();
            if (string.IsNullOrWhiteSpace(result))
            {
                GNLog.Warning("잘못된 string 값입니다.");
                return null;
            }
            return result;
        }

        public static object ConvertKey(Type keyType, object key)
        {
            if (keyType == typeof(string)) return key;
            if (keyType.IsEnum)
            {
                if (Enum.TryParse(keyType, key.ToString(), true, out object result))
                {
                    return result;
                }
                else
                {
                    GNLog.ParseFail(keyType);
                    return null;
                }
            }
            if (keyType == typeof(int)) return Convert.ToInt32(key);
            if (keyType == typeof(long)) return Convert.ToInt64(key);
            if (keyType == typeof(float)) return Convert.ToSingle(key);
            if (keyType == typeof(double)) return Convert.ToDouble(key);
            if (keyType == typeof(bool)) return Convert.ToBoolean(key);
            if (keyType == typeof(DateTime)) return Convert.ToDateTime(key);
            if (keyType == typeof(ClockTime)) return new ClockTime(Convert.ToInt32(key));
            if (keyType == typeof(UnixTime)) return new UnixTime(Convert.ToInt64(key));

            GNLog.Error($"{keyType.Name} is not a supported type.");
            return null;
        }

        public static object ConvertIComparable(Type genericType, object propertyValue)
        {
            if (genericType == typeof(int)) return Convert.ToInt32(propertyValue);
            if (genericType == typeof(long)) return Convert.ToInt64(propertyValue);
            if (genericType == typeof(float)) return Convert.ToSingle(propertyValue);
            if (genericType == typeof(double)) return Convert.ToDouble(propertyValue);
            if (genericType == typeof(DateTime)) return Convert.ToDateTime(propertyValue);
            if (genericType == typeof(ClockTime)) return new ClockTime(Convert.ToInt32(propertyValue));
            if (genericType == typeof(UnixTime)) return new UnixTime(Convert.ToInt64(propertyValue));
            return propertyValue;
        }
    }
}