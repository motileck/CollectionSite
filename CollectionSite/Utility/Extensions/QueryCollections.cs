using CollectionSite.Utility.Constants;

namespace CollectionSite.Utility.Extensions
{
    public static class QueryCollections
    {
        public static string ReturnUrl(this IQueryCollection collection) => collection[CookiesConstants.ReturnUrlName]!;
    }
}
