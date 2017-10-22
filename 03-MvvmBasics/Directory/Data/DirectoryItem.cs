using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeViewsAndValueConverters.Directory.Data
{
    public class DirectoryItem
    {
        public string FullPath { get; set; }
        public DirectoryItemType Type { get; set; }

        public string Name
        {
            get
            {
                if (Type == DirectoryItemType.Drive)
                    return FullPath;

                return System.IO.Path.GetFileName(FullPath);
            }
        }
    }
}
