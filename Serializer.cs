using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Diagnostics;

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

        public string dictToString(Dictionary<string, string> dict)
        {
            List<string> elements = new List<string>();
            foreach (var kvp in dict)
            {
                elements.Add($"{kvp.Key}${kvp.Value}");
            }
            return String.Join(";", elements.ToArray());
        }
        public Point stringToPoint(string str)
        {
            Debug.WriteLine(str);
            str = str.Trim('{', '}', ' ', '\t', '\n');
            string[] parts = str.Split(',', '=');
            int x = 0;
            int y = 0;
            
            if (parts.Length == 4)
            {
                if (int.TryParse(parts[1], out x) && int.TryParse(parts[3], out y))
                {
                    return new Point(x, y);
                }
            }
            Debug.WriteLine(str);
            throw new FormatException("Неверный формат строки для преобразования в точку");
        }
        public Dictionary<string, string> stringToParametersDict(string str)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (str == null || str == "") 
            { 
                return result; 
            }
            string[] pairs = str.Split(';');
            foreach (string pair in pairs)
            {
                // Разделяем пару на ключ и значение
                string[] keyValue = pair.Split('$');

                // Проверяем, что у нас действительно есть пара ключ-значение
                if (keyValue.Length == 2)
                {
                    string key = keyValue[0];
                    string value = keyValue[1];

                    // Добавляем ключ и значение в словарь
                    result[key] = value;
                }
                else
                {
                    throw new FormatException("Invalid format for key-value pair: " + pair);
                }
                
            }
            return result;
        }
    }
}
