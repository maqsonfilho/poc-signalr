namespace SignalServer.HashMap;

public static class DictionaryVsList
{
    public static void Teste()
    {
        List<string> list = new List<string>();
        //0 -> "1231232"
        //1 -> "1231232"
        //2 -> "1231232"
        /**
         * 
         * 
         */
        //n -> "asdasdasda"

        list[list.Count-1].ToString();

        Dictionary<int, string> dicAsList = new Dictionary<int, string>();
        //0 -> "1231232"
        //1 -> "1231232"
        //2 -> "1231232"
        /**
         * 
         * 
         */
        //n -> "asdasdasda"
        dicAsList.Add(999, "ëu que escolhi");
        string valor = "";
        dicAsList.TryGetValue(999, out valor);

        Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

    }
}
