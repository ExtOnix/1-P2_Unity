public class API 
{
    public const string DOMAIN = "https://quizzapi.jomoreschi.fr/api/v1/";
    public static string Questions(string _category, string _difficulty) => $"{DOMAIN}quiz?limit=1&category={_category}&difficulty={_difficulty}";
}
