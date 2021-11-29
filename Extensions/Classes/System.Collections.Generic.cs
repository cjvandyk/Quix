#pragma warning disable IDE1006, IDE0017, CS0162, IDE0060, IDE0079 // Naming Styles, Simplify declaration (FQCN used), break after return, Remove unused (string[] args, Remove unnecessary suppression)

/// <summary>
/// Author: Cornelius J. van Dyk blog.cjvandyk.com @cjvandyk
/// This code is provided under GNU GPL 3.0 and is a copyrighted work of the
/// author and contributors.  Please see:
/// https://github.com/cjvandyk/Quix/blob/master/LICENSE
/// </summary>

using System;

using Microsoft.Graph;
using System.Collections.Generic;

namespace Extensions
{
    public static class IListItemsCollectionPage
    {
        /// <summary>
        /// Shorthand extension encapsulating Convert.ToInt16() allowing
        /// syntax changes from this:
        /// ...Convert.ToInt16(doubleValue)...
        /// to:
        /// ...doubleValue.ToInt16()...
        /// </summary>
        /// <param name="dbl">The double value to convert.</param>
        /// <returns>The value as Int16 format.</returns>
        public static List<Dictionary<string, string>> ToDictionary(this ListItemsCollectionPage items)
        {
            List<Dictionary<string, string>> lst = new List<Dictionary<string, string>>();
            foreach (ListItem item in items)
            {
                //lst.Add( item.Fields.AdditionalData["Title"])
            }
//            Microsoft.Graph.GraphServiceClient client = new Microsoft.Graph.GraphServiceClient(auth);
//            var i = client.Sites[""].Lists[""].Items.Request().GetAsync();
            return lst;
        }
    }
}
