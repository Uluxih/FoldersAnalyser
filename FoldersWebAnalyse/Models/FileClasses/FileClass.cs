using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoldersWebAnalyse.Models
{
    public class FileClass : IComparable
    {
        public string Name;
        public long Size;
        public FileClass(string name)
        {
            this.Name = name;
        }

        public int CompareTo(object obj)
        {
            if (obj is FileClass file) return file.Size.CompareTo(Size);
            else throw new ArgumentException("Некорректное значение параметра");
        }

        public string GetSize()
        {
            if (Size > Math.Pow(10, 9))
            {
                double Usefullsize = Math.Round(this.Size / Math.Pow(10, 9), 2);
                return Convert.ToString(Usefullsize + " Гб");
            }
            else if (Size > Math.Pow(10, 6))
            {
                double Usefullsize = Math.Round(this.Size / Math.Pow(10, 6), 2);
                return Convert.ToString(Usefullsize + " Мб");
            }
            else if (Size > Math.Pow(10, 3))
            {
                double Usefullsize = Math.Round(this.Size / Math.Pow(10, 3), 2);
                return Convert.ToString(Usefullsize + " Кб");
            }
            else
            {
                return Convert.ToString(Size + " байт");
            }
        }
    }
}
