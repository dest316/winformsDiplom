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
            using (StreamWriter stream = new StreamWriter(filepath, false))
            {
                stream.Write(text);
            }
        }
        public string createXmlTag(string tagName, Dictionary<string, string> attrs, string content, int amountTab) 
        {
            string attrStr = "";
            string isSpaceAfterTagName = attrs == null || attrs.Count == 0 ? "": " ";
            if (attrs != null)
            {
                List<string> attrList = new List<string>();
                foreach (var pair in attrs)
                {
                    attrList.Add($"{pair.Key}=\"{pair.Value}\"");
                }
                attrStr = String.Join(" ", attrList.ToArray());
            }
            string tabPrefix = String.Concat(Enumerable.Repeat("\t", amountTab));
            return $"{tabPrefix}<{tagName}{isSpaceAfterTagName}{attrStr}>\n{tabPrefix}{content}\n{tabPrefix}</{tagName}>\n";
        }

        public string createXmlHead()
        {
            string gs = createXmlTag("globalSettings", null, "", 1);
            string result = createXmlTag("model", null, gs, 0);
            return result;
        }
    }
    
}
