using Newtonsoft.Json;
using System.Web;

namespace Notes.Identity.Helpers;

public static class WebHelper
{
    /// <summary>
    /// Deserialize a value from a hidden HTML Form field which was serialized
    /// with SerializeForHidden to its original type.
    /// </summary>
    /// <typeparam name="T">Type to deserialize to</typeparam>
    /// <param name="value">serialized and HtmlEncoded string from HTML form</param>
    /// <param name="_">Target property only used to simplify detection of T. May be null.</param>
    /// <returns>Deserialized object or null when value was null or empty</returns>
    public static T? DeserializeForHidden<T>(this string value, T _)
    {
        if (String.IsNullOrEmpty(value))
            return default;

        return JsonConvert.DeserializeObject<T>(HttpUtility.HtmlDecode(value));
    }

    /// <summary>
    /// Serialize a complex value (like a List) to be stored in a hidden HTML Form field
    /// </summary>
    /// <param name="value">Value to serialize</param>
    /// <returns>Json serialized and HtmlEncoded string</returns>
    public static string? SerializeForHidden(this object value)
    {
        if (value is null)
            return default;

        return HttpUtility.HtmlEncode(
            JsonConvert.SerializeObject(value, 
                new JsonSerializerSettings 
                { 
                    DefaultValueHandling = DefaultValueHandling.Ignore 
                }));
    }
}