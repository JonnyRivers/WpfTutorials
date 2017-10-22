using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeViewsAndValueConverters.Directory
{
    using Data;

    // This is complete bollocks.  Inject this.
    public static class DirectoryStructure
    {
        public static List<DirectoryItem> GetLogicalDrives()
        {
            string[] logicalDrivePaths = System.IO.Directory.GetLogicalDrives();
            IEnumerable<DirectoryItem> logicalDrives = logicalDrivePaths.Select(
                drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive });

            return logicalDrives.ToList();
        }

        public static List<DirectoryItem> GetDirectoryContents(string path)
        {
            var items = new List<DirectoryItem>();

            try
            {
                string[] directories = System.IO.Directory.GetDirectories(path);
                foreach (string directory in directories)
                {
                    var subItem = new DirectoryItem
                    {
                        Type = DirectoryItemType.Folder,
                        FullPath = directory
                    };

                    items.Add(subItem);
                }
            }
            catch { }

            try
            {
                string[] files = System.IO.Directory.GetFiles(path);
                foreach (string file in files)
                {
                    var subItem = new DirectoryItem
                    {
                        Type = DirectoryItemType.File,
                        FullPath = file
                    };

                    items.Add(subItem);
                }
            }
            catch { }

            return items;
        }
    }
}
