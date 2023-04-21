using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FoldersWebAnalyse.Models.Folder
{
    public class GeterDirs
    {
        /// <summary>
        /// Рекурсивно анализирует все вложенные папки и файлы на предмет занимаеого объема
        /// </summary>
        /// <param name="direct">Ссылка на FolderClass, внутри которого надо проанализировать файлы и папки
        /// <returns>Возвращает FolderClass, внутри которого упорядодчены по размеры все вложенные FolderClass и вложенные файлы
        public static FolderClass SetDirs(FolderClass direct)
        {
            var dirName = direct.Name;
            // если папка существует
            if (Directory.Exists(dirName))
            {
                try
                {
                    string[] dirs = Directory.GetDirectories(dirName);
                    foreach (string s in dirs)
                    {
                        FolderClass innerFolderClass = new FolderClass(s);
                        direct.folders.Add(innerFolderClass);
                        SetDirs(innerFolderClass);
                        direct.Size += innerFolderClass.Size;
                    }
                    string[] files = Directory.GetFiles(dirName);
                    FileInfo file;
                    int a = 0;
                    foreach (string f in files)
                    {
                        var myFile = new FileClass(f);
                        file = new FileInfo(f);
                        direct.files.Add(myFile);
                        direct.Size += file.Length;
                        myFile.Size = file.Length;
                    }
                }
                catch
                {
                }
            }
            direct.folders.Sort();
            direct.files.Sort();
            return direct;
        }
    }
}
