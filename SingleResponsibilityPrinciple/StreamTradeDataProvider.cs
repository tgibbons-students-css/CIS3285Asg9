using System.Collections.Generic;
using System.IO;

using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class StreamTradeDataProvider : ITradeDataProvider
    {
        public StreamTradeDataProvider(Stream stream)
        {
            this.stream = stream;
        }

        /// <summary>
        /// Read the text file containing the trades. This file should in in the format of one trade per line
        ///    GBPUSD,1000,1.51
        /// </summary>
        /// <param name="stream"> File must be passed in as a Stream. </param>
        /// <returns> Returns a list of strings, one for each string for each line in the file </returns>

        public IEnumerable<string> GetTradeData()
        {
            var tradeData = new List<string>();
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }
            return tradeData;
        }

        private readonly Stream stream;
    }
}
