// <copyright file="BoxEventFilter.cs" company="itracks" >
//      Copyright (c) itracks All Right Reserved
// </copyright>
// <author>sean.gifford </author>
// <date>12/15/2015</date> 

using System;
using System.Linq;

namespace Box.V2.Models
{
    /// <summary>
    /// The possible values that may be used to filter the types of events that are returned when querying for events.
    /// </summary>
    public enum BoxEventFilter
    {
        /// <summary>
        /// Returns everything
        /// </summary>
        All,

        /// <summary>
        /// Returns tree changes
        /// </summary>
        FolderChanges,

        /// <summary>
        /// Returns tree changes only for sync folders
        /// </summary>
        SyncedFolderChanges
    }
}