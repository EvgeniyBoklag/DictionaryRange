using WebApiTestApplication.Services;

namespace WebApiTestApplication.Tests.Const
{
    internal class WordsServiceFake
    {
        public static volatile string[] Words = new string[]
            {
                "azzara",
                "azzarito",
                "azzedine",
                "azzuolo",
                "azzur",
                "baagandji",
                "collasping",
                "collat",
                "collatable",
                "collate",
                "collated",
                "collatee",
                "collateral",
                "collaterally",
                "collaterals",
                "collates",
                "gambang",
                "gambar",
                "gambaroff",
                "jargonal",
                "jargoned",
                "jargoneer",
                "metred",
                "metreless",
                "metres",
                "overface",
                "overfacile",
                "overfacilely",
                "plumulate",
                "plumule",
                "plumuliform",
                "plumulose",
                "plumville",
                "plumy",
                "readln",
                "readlyn",
                "readme"
            };
        public static volatile IWordsRangeService WordsRangeService = new WordsRangeService(Words);
    }
}