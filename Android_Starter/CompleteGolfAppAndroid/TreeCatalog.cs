using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CompleteGolfAppAndroid;


namespace CompleteGolfAppAndroid
{
    // TreePage: contains image resource ID and caption for a tree:
    public class TreePage
    {
        // Image ID for this tree image:
        public int imageId;

        // Caption text for this image:
        public string caption;

        public string sometext;

        // Returns the ID of the image:
        public int ImageID { get { return imageId; } }

        // Returns the caption text for the image:
        public string Caption { get { return caption; } }

        // Returns the caption text for the image:
        public string SomeText { get { return sometext; } }
    }

    // Tree catalog: holds image resource IDs and caption text:
    public class TreeCatalog
    {
        // Built-in tree catalog (could be replaced with a database)
        static TreePage[] treeBuiltInCatalog = {
            new TreePage { imageId = Resource.Drawable.larch,
                           caption = "No.1: The Larch", sometext = "tree 1" }, 
            new TreePage { imageId = Resource.Drawable.maple,
                           caption = "No.2: Maple", sometext = "tree 2" },
            new TreePage { imageId = Resource.Drawable.birch,
                           caption = "No.3: Birch", sometext = "tree 3" },
            new TreePage { imageId = Resource.Drawable.coconut,
                           caption = "No.4: Coconut", sometext = "tree 4" },
            new TreePage { imageId = Resource.Drawable.oak,
                           caption = "No.5: Oak", sometext = "tree 5" },
            new TreePage { imageId = Resource.Drawable.fir,
                           caption = "No.6: Fir", sometext = "tree 6" },
            new TreePage { imageId = Resource.Drawable.pine,
                           caption = "No.7: Pine", sometext = "tree 7" },
            new TreePage { imageId = Resource.Drawable.elm,
                           caption = "No.8: Elm", sometext = "tree 8" },
        };

        // Array of tree pages that make up the catalog:
        private TreePage[] treePages;

        // Create an instance copy of the built-in tree catalog:
        public TreeCatalog() { treePages = treeBuiltInCatalog; }

        // Indexer (read only) for accessing a tree page:
        public TreePage this[int i] { get { return treePages[i]; } }

        // Returns the number of tree pages in the catalog:
        public int NumTrees { get { return treePages.Length; } }
    }
}