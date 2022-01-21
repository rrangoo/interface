using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @interface
{
    // Класс который представляет из себя контейнер для работы со входными данными.
    // Тут можно прописать условия всякие, ограничния и тд.
    public class InputData
    {
        string[] data = new string[4];

        public InputData(string method, string type, string obj, int count)
        {
            data[0] = method;
            data[1] = type;
            data[2] = obj;
            data[3] = count.ToString();
        }

        // Проверка на пустоту на домашней странице.
        public bool isEmpty()
        {
            foreach (var item in data)
            {
                if (item == "")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
