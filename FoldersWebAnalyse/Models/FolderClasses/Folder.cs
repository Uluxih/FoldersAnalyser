using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoldersWebAnalyse.Models
{
    public class FolderClass : IComparable
    {
        public string Name;
        public long Size;
        public List<FolderClass> folders;
        public List<FileClass> files;
        public FolderClass(string name)
        {
            this.Name = name;
            folders = new List<FolderClass>();
            files = new List<FileClass>();
        }

        public int CompareTo(object obj)
        {
            if (obj is FolderClass fold) return fold.Size.CompareTo(Size);
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
            else if(Size > Math.Pow(10, 3))
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
