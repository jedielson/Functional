namespace Functional.CrossCutting.Util
{
    using System;

    public static class GuidUtils
    {
        public static bool IsEmpty(this Guid guid)
        {
            return guid == Guid.Parse("{00000000-0000-0000-0000-000000000000}");
        }
    }
}
