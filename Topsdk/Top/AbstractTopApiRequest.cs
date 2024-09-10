using Topsdk.Util;

namespace Topsdk.Top;

public abstract class AbstractTopApiRequest
{
    public abstract IDictionary<string, string> ToRequestParam();

    public abstract IDictionary<string, TopFileItem> ToFileParam();

    public abstract string GetApiCode();
}