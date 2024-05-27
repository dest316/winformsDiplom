using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dIplom3
{
    public class Serializer
    {
        public void Serialize(string filepath, string text)
        {
            using (StreamWriter stream = new StreamWriter(filepath))
            {
                stream.Write(text);
            }
        }
        public string createXmlTag(string tagName, Dictionary<string, string> attrs, string content, int amountTab) 
        {
            List<string> attrList = new List<string>();
            foreach (var pair in attrs)
            {
                attrList.Add($"{pair.Key}=\"{pair.Value}");
            }
            string attrStr = String.Join(" ", attrList.ToArray());
            string tabPrefix = String.Concat(Enumerable.Repeat("\t", amountTab));
            return $"{tabPrefix}<{tagName} {attrStr}>{content}</{tagName}>";
        }
    }
    
}
