using System;
using System.ComponentModel;

namespace LibraryCore.BookMapp
{
    /// <summary>
    /// this enum have all active book type that is in the libery
    /// </summary>
    public enum BookType : int
    {
        [Description("Journal")]
        Journal = 0, [Description("Novel")]
        Novel = 1, [Description("Novellcollection")]
        Novellcollection = 2
    }
}